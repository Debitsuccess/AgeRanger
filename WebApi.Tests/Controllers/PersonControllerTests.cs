using System.Linq;

using Moq;

using NUnit.Framework;

using WebApi.Contracts;
using WebApi.Controllers;
using WebApi.Services;

namespace WebApi.Tests.Controllers
{
	[TestFixture]
	public class PersonControllerTests
	{
		private Mock<IPersonService> personServiceMock;
		private PersonController controller;

		private int savedCount;
		private Person lastSavedPerson;
		private int lastDeletedId;


		[OneTimeSetUp]
		public void Setup()
		{
			var fred = new Person
			{
				Id = 1,
				FirstName = "Fred",
				LastName = "Jones",
				Age = 3
			};
			var mary = new Person
			{
				Id = 2,
				FirstName = "Mary",
				LastName = "Jones",
				Age = 42
			};

			personServiceMock = new Mock<IPersonService>();
			personServiceMock.Setup(service => service.GetAllPeople())
				.Returns(
					new[]
					{
						fred,
						mary
					}
				);

			personServiceMock.Setup(service => service.GetPerson(1))
				.Returns(fred);

			personServiceMock.Setup(service => service.GetPerson(2))
				.Returns(mary);

			personServiceMock.Setup(service => service.SaveNewPerson(It.IsAny<Person>()))
				.Callback<Person>(
					person =>
					{
						savedCount++;
						lastSavedPerson = person;
					}
				);

			personServiceMock.Setup(service => service.UpdatePerson(It.Is<Person>(person => person.Id > 0 && person.Id < 3)))
				.Callback<Person>(
					person =>
					{
						lastSavedPerson = person;
					}
				);

			personServiceMock.Setup(service => service.RemovePerson(It.IsAny<int>()))
				.Callback<int>(
					id =>
					{
						lastDeletedId = id;
					}
				);


			controller = new PersonController(personServiceMock.Object);
		}

		[SetUp]
		public void ClearFlags()
		{
			savedCount = 2;
			lastSavedPerson = null;
		}


		[Test]
		public void GetAllReturnsAll()
		{
			var result = controller.Get().ToList();

			Assert.AreEqual(2, result.Count, "Count");
		}

		[Test]
		public void GetReturnsOne()
		{
			Assert.NotNull(controller.Get(1), "Get(1)");
			Assert.AreEqual("Fred", controller.Get(1).FirstName, "Get(1).FirstName");

			Assert.NotNull(controller.Get(2), "Get(2)");
			Assert.AreEqual("Mary", controller.Get(2).FirstName, "Get(2).FirstName");

			Assert.Null(controller.Get(3), "Get(3)");
		}

		[Test]
		public void PostSavesNewPerson()
		{
			controller.Post(
				new Person
				{
					FirstName = "Jill",
					LastName = "Jones",
					Age = 15
				}
			);

			Assert.AreEqual(3, savedCount, "Post savedCount");
			Assert.AreEqual("Jill", lastSavedPerson?.FirstName, "Post firstName");
		}

		[Test]
		public void PutUpdatesTheRightPerson()
		{
			controller.Put(
				2,
				new Person
				{
					Id = 3,
					FirstName = "Contrary",
					LastName = "Jones",
					Age = 39	// and some months...
				}
			);

			Assert.AreEqual(2, savedCount, "Put savedCount");
			Assert.AreEqual(2, lastSavedPerson?.Id, "Put id");
			Assert.AreEqual("Contrary", lastSavedPerson?.FirstName, "Put firstName");
		}

		[Test]
		public void DeleteDeletesTheRightId()
		{
			controller.Delete(3);

			Assert.AreEqual(3, lastDeletedId, "Delete id");
		}
	}
}
