using System;
using System.Linq;

using Moq;

using NUnit.Framework;

using Tools;

using WebApi.Domain;
using WebApi.Repositories;
using WebApi.Services;

using ContractPerson = WebApi.Contracts.Person;
using DomainPerson = WebApi.Domain.Person;

namespace WebApi.Tests.Services
{
	[TestFixture]
	public class PersonServiceTests
	{
		private Mock<IWritableRepository<int, Person>> personRepoMock;
		private Mock<IAgeGroupService> ageGroupServiceMock;
		private PersonService personService;


		[SetUp]
		public void Setup()
		{
			Current.FreezeUtcNow();

			personRepoMock = new Mock<IWritableRepository<int, DomainPerson>>();
			var people = new[]
			{
				new DomainPerson
				{
					Id = 1,
					FirstName = "Fred",
					LastName = "Jones",
					Age = 23U,
					Created = Current.UtcNow.AddHours(-2),
					Modified = Current.UtcNow.AddHours(-1),
					Version = 2
				},
				new DomainPerson
				{
					Id = 2,
					FirstName = "Mary",
					LastName = "Jones",
					Age = 13U,
					Created = Current.UtcNow.AddDays(-1),
					Modified = Current.UtcNow.AddHours(-2),
					Version = 4
				}
			};
			personRepoMock.Setup(repo => repo.GetAll())
				.Returns(people.AsQueryable)
				.Verifiable();

			personRepoMock.Setup(repo => repo.Get(It.IsAny<int>()))
				.Returns<int>(id => people.FirstOrDefault(person => person.Id.Equals(id)));


			ageGroupServiceMock = new Mock<IAgeGroupService>();
			ageGroupServiceMock.Setup(service => service.GetAgeGroup(23U))
				.Returns(new AgeGroup { Description = "older" })
				.Verifiable();

			ageGroupServiceMock.Setup(service => service.GetAgeGroup(13U))
				.Returns(new AgeGroup { Description = "younger" })
				.Verifiable();


			personService = new PersonService(personRepoMock.Object, ageGroupServiceMock.Object);
		}


		[Test]
		public void GetAllPeopleTest()
		{
			var result = personService.GetAllPeople().ToList();

			Assert.AreEqual(2, result.Count, "Count");
			CollectionAssert.AllItemsAreNotNull(result, "NotNull");
			CollectionAssert.AllItemsAreInstancesOfType(result, typeof(ContractPerson), "ResultType");

			Assert.AreEqual(1, result[0].Id, "[0] ID");
			Assert.AreEqual("Fred", result[0].FirstName, "[0] FirstName");
			Assert.AreEqual("Jones", result[0].LastName, "[0] LastName");
			Assert.AreEqual(23U, result[0].Age, "[0] Age");
			Assert.AreEqual(Current.UtcNow.AddHours(-2), result[0].Created, "[0] Created");
			Assert.AreEqual(Current.UtcNow.AddHours(-1), result[0].Modified, "[0] Modified");
			Assert.AreEqual(2, result[0].Version, "[0] Version");

			Assert.AreEqual("older", result[0].AgeGroup, "[0] AgeGroup");

			Assert.AreEqual(2, result[1].Id, "[1] ID");
			Assert.AreEqual("Mary", result[1].FirstName, "[1] FirstName");
			Assert.AreEqual("Jones", result[1].LastName, "[1] LastName");
			Assert.AreEqual(13U, result[1].Age, "[1] Age");
			Assert.AreEqual(Current.UtcNow.AddDays(-1), result[1].Created, "[1] Created");
			Assert.AreEqual(Current.UtcNow.AddHours(-2), result[1].Modified, "[1] Modified");
			Assert.AreEqual(4, result[1].Version, "[1] Version");

			Assert.AreEqual("younger", result[1].AgeGroup, "[1] AgeGroup");

			ageGroupServiceMock.VerifyAll();
			personRepoMock.Verify(repo => repo.GetAll(), Times.Once);
		}

		[Test]
		public void GetPersonForExistingTest()
		{
			var result = personService.GetPerson(2);

			Assert.IsNotNull(result);

			Assert.AreEqual(2, result.Id, "ID");
			Assert.AreEqual("Mary", result.FirstName, "FirstName");
			Assert.AreEqual("Jones", result.LastName, "LastName");
			Assert.AreEqual(13U, result.Age, "Age");
			Assert.AreEqual(Current.UtcNow.AddDays(-1), result.Created, "Created");
			Assert.AreEqual(Current.UtcNow.AddHours(-2), result.Modified, "Modified");
			Assert.AreEqual(4, result.Version, "Version");

			Assert.AreEqual("younger", result.AgeGroup, "AgeGroup");

			ageGroupServiceMock.Verify(service => service.GetAgeGroup(13U), Times.Once);
			personRepoMock.Verify(repo => repo.Get(2), Times.Once);
		}

		[Test]
		public void GetPersonForMissingTest()
		{
			var result = personService.GetPerson(99);

			Assert.IsNull(result);

			personRepoMock.Verify(repo => repo.Get(99), Times.Once);
		}


		[Test]
		public void SaveNullNewPersonTest()
		{
			Assert.Throws<ArgumentNullException>(() => personService.SaveNewPerson(null));
		}

		[Test]
		public void SaveValidNewPersonTest()
		{
			DomainPerson saved = null;

			personRepoMock.Setup(repo => repo.Put(It.IsAny<DomainPerson>()))
				.Callback<DomainPerson>(person => saved = person)
				.Verifiable();

			personService.SaveNewPerson(
				new ContractPerson
				{
					Id = 22,
					FirstName = "new",
					LastName = "guy",
					Age = 99U
				}
			);

			personRepoMock.Verify(repo => repo.Put(It.IsAny<DomainPerson>()));

			Assert.IsNotNull(saved);
			Assert.AreEqual(-1, saved.Id, "Saved ID");
			Assert.AreEqual(Current.UtcNow, saved.Created, "Saved Created");
			Assert.AreEqual(Current.UtcNow, saved.Modified, "Saved Modified");
			Assert.AreEqual(0, saved.Version, "Saved Version");
			Assert.AreEqual("new", saved.FirstName, "Saved FirstName");
			Assert.AreEqual("guy", saved.LastName, "Saved LastName");
			Assert.AreEqual(99U, saved.Age, "Saved Age");
		}

		[Test]
		public void UpdateNullPersonTest()
		{
			Assert.Throws<ArgumentNullException>(() => personService.UpdatePerson(null));
		}

		[Test]
		public void UpdateValidPersonTest()
		{
			DomainPerson saved = null;

			personRepoMock.Setup(repo => repo.Put(It.IsAny<DomainPerson>()))
				.Callback<DomainPerson>(person => saved = person)
				.Verifiable();

			personService.UpdatePerson(
				new ContractPerson
				{
					Id = 2,
					Version = 4,
					FirstName = "new",
					LastName = "guy",
					Age = 99U
				}
			);

			personRepoMock.Verify(repo => repo.Put(It.IsAny<DomainPerson>()));

			Assert.IsNotNull(saved);
			Assert.AreEqual(2, saved.Id, "Updated ID");
			Assert.AreEqual(Current.UtcNow, saved.Created, "Updated Created");
			Assert.AreEqual(Current.UtcNow, saved.Modified, "Updated Modified");
			Assert.AreEqual(4, saved.Version, "Updated Version");
			Assert.AreEqual("new", saved.FirstName, "Updated FirstName");
			Assert.AreEqual("guy", saved.LastName, "Updated LastName");
			Assert.AreEqual(99U, saved.Age, "Updated Age");
		}


		[Test]
		public void RemovePersonTest()
		{
			personRepoMock.Setup(repo => repo.Delete(42))
				.Verifiable();

			personService.RemovePerson(42);

			personRepoMock.Verify(repo => repo.Delete(42), Times.Once);
		}


		[TearDown]
		public void ResetCurrent()
		{
			Current.Reset();
		}
	}
}
