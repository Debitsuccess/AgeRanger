using System.Linq;

using NUnit.Framework;

using WebApi.Domain;
using WebApi.Repositories.Exceptions;
using WebApi.Repositories.InMemory;

namespace WebApi.Tests.Repositories.InMemory
{
	[TestFixture]
	public class PersonRepositoryTests
	{
		private class InstrumentedPersonWritableRepository : PersonWritableRepository
		{
			public uint GetValuesCallCount;
			public uint GetNextIdCallCount;
			public uint SaveCallCount;
			public uint UpdateCallCount;
			public uint DeleteCallCount;

			public int LastNextId;

			public Person LastProvidedPerson;


			protected override IQueryable<Person> GetValues()
			{
				GetValuesCallCount++;
				return base.GetValues();
			}

			protected override int GetNextId()
			{
				GetNextIdCallCount++;
				LastNextId = base.GetNextId();
				return LastNextId;
			}

			protected override void Save(Person value)
			{
				SaveCallCount++;
				LastProvidedPerson = value;
				base.Save(value);
			}

			protected override void Update(Person value)
			{
				UpdateCallCount++;
				LastProvidedPerson = value;
				base.Update(value);
			}

			protected override void Delete(Person value)
			{
				DeleteCallCount++;
				LastProvidedPerson = value;
				base.Delete(value);
			}
		}

		[Test]
		public void GetAll()
		{
			var personRepoMock = new InstrumentedPersonWritableRepository();

			Assert.AreEqual(0, personRepoMock.GetValuesCallCount, "GetValues before");
			Assert.AreEqual(0, personRepoMock.GetNextIdCallCount, "GetNextId before");
			Assert.AreEqual(0, personRepoMock.SaveCallCount, "Save before");
			Assert.AreEqual(0, personRepoMock.UpdateCallCount, "Update before");
			Assert.AreEqual(0, personRepoMock.DeleteCallCount, "Delete before");

			personRepoMock.GetAll();

			Assert.AreEqual(1, personRepoMock.GetValuesCallCount, "GetValues");
			Assert.AreEqual(0, personRepoMock.GetNextIdCallCount, "GetNextId");
			Assert.AreEqual(0, personRepoMock.SaveCallCount, "Save");
			Assert.AreEqual(0, personRepoMock.UpdateCallCount, "Update");
			Assert.AreEqual(0, personRepoMock.DeleteCallCount, "Delete");
		}

		[Test]
		public void Get()
		{
			var personRepoMock = new InstrumentedPersonWritableRepository();

			Assert.AreEqual(0, personRepoMock.GetValuesCallCount, "GetValues before");
			Assert.AreEqual(0, personRepoMock.GetNextIdCallCount, "GetNextId before");
			Assert.AreEqual(0, personRepoMock.SaveCallCount, "Save before");
			Assert.AreEqual(0, personRepoMock.UpdateCallCount, "Update before");
			Assert.AreEqual(0, personRepoMock.DeleteCallCount, "Delete before");

			personRepoMock.Get(1);

			Assert.AreEqual(1, personRepoMock.GetValuesCallCount, "GetValues");
			Assert.AreEqual(0, personRepoMock.GetNextIdCallCount, "GetNextId");
			Assert.AreEqual(0, personRepoMock.SaveCallCount, "Save");
			Assert.AreEqual(0, personRepoMock.UpdateCallCount, "Update");
			Assert.AreEqual(0, personRepoMock.DeleteCallCount, "Delete");
		}


		[Test]
		public void PutSave()
		{
			var personRepoMock = new InstrumentedPersonWritableRepository();

			Assert.AreEqual(0, personRepoMock.GetValuesCallCount, "GetValues before");
			Assert.AreEqual(0, personRepoMock.GetNextIdCallCount, "GetNextId before");
			Assert.AreEqual(0, personRepoMock.SaveCallCount, "Save before");
			Assert.AreEqual(0, personRepoMock.UpdateCallCount, "Update before");
			Assert.AreEqual(0, personRepoMock.DeleteCallCount, "Delete before");

			personRepoMock.Put(
				new Person
				{
					Id = 2,
					Version = 0,
					FirstName = "test",
					LastName = "person",
					Age = 42U
				}
			);

			Assert.AreEqual(0, personRepoMock.GetValuesCallCount, "GetValues");
			Assert.AreEqual(1, personRepoMock.GetNextIdCallCount, "GetNextId");
			Assert.AreEqual(1, personRepoMock.SaveCallCount, "Save");
			Assert.AreEqual(0, personRepoMock.UpdateCallCount, "Update");
			Assert.AreEqual(0, personRepoMock.DeleteCallCount, "Delete");
		}

		[Test]
		public void PutUpdateMissing()
		{
			var personRepoMock = new InstrumentedPersonWritableRepository();

			Assert.Throws<UpdateAgainstMissingRecordException<int, Person>>(
				() => personRepoMock.Put(
					new Person
					{
						Id = 2,
						Version = 3,
						FirstName = "test",
						LastName = "person",
						Age = 42U
					}
				)
			);
		}

		[Test]
		public void PutUpdatePresentNoConcurrentClash()
		{
			var personRepoMock = new InstrumentedPersonWritableRepository();

			personRepoMock.Put(
				new Person
				{
					Id = -1,
					Version = 0,
					FirstName = "test",
					LastName = "person",
					Age = 42U
				}
			);

			Assert.AreEqual(0, personRepoMock.GetValuesCallCount, "GetValues before");
			Assert.AreEqual(1, personRepoMock.GetNextIdCallCount, "GetNextId before");
			Assert.AreEqual(1, personRepoMock.SaveCallCount, "Save before");
			Assert.AreEqual(0, personRepoMock.UpdateCallCount, "Update before");
			Assert.AreEqual(0, personRepoMock.DeleteCallCount, "Delete before");

			personRepoMock.Put(
				new Person
				{
					Id = 1,
					Version = 1,
					FirstName = "test",
					LastName = "person",
					Age = 42U
				}
			);

			Assert.AreEqual(1, personRepoMock.GetValuesCallCount, "GetValues");
			Assert.AreEqual(1, personRepoMock.GetNextIdCallCount, "GetNextId");
			Assert.AreEqual(1, personRepoMock.SaveCallCount, "Save");
			Assert.AreEqual(1, personRepoMock.UpdateCallCount, "Update");
			Assert.AreEqual(0, personRepoMock.DeleteCallCount, "Delete");
		}

		[Test]
		public void PutUpdatePresentWithConcurrentClash()
		{
			var personRepoMock = new InstrumentedPersonWritableRepository();

			personRepoMock.Put(
				new Person
				{
					Id = -1,
					Version = 0,
					FirstName = "test",
					LastName = "person",
					Age = 42U
				}
			);

			Assert.AreEqual(0, personRepoMock.GetValuesCallCount, "GetValues before");
			Assert.AreEqual(1, personRepoMock.GetNextIdCallCount, "GetNextId before");
			Assert.AreEqual(1, personRepoMock.SaveCallCount, "Save before");
			Assert.AreEqual(0, personRepoMock.UpdateCallCount, "Update before");
			Assert.AreEqual(0, personRepoMock.DeleteCallCount, "Delete before");

			// "meanwhile, on another thread..."
			personRepoMock.Put(
				new Person
				{
					Id = 1,
					Version = 1,
					FirstName = "test",
					LastName = "person",
					Age = 42U
				}
			);

			// "back here"
			Assert.Throws<ConcurrentModificationException<int, Person>>(
				() => personRepoMock.Put(
					new Person
					{
						Id = 1,
						Version = 1,
						FirstName = "test",
						LastName = "person",
						Age = 42U
					}
				)
			);
		}


		[Test]
		public void DeleteMissing()
		{
			var personRepoMock = new InstrumentedPersonWritableRepository();

			Assert.AreEqual(0, personRepoMock.GetValuesCallCount, "GetValues before");
			Assert.AreEqual(0, personRepoMock.GetNextIdCallCount, "GetNextId before");
			Assert.AreEqual(0, personRepoMock.SaveCallCount, "Save before");
			Assert.AreEqual(0, personRepoMock.UpdateCallCount, "Update before");
			Assert.AreEqual(0, personRepoMock.DeleteCallCount, "Delete before");

			personRepoMock.Delete(1);

			Assert.AreEqual(1, personRepoMock.GetValuesCallCount, "GetValues");
			Assert.AreEqual(0, personRepoMock.GetNextIdCallCount, "GetNextId");
			Assert.AreEqual(0, personRepoMock.SaveCallCount, "Save");
			Assert.AreEqual(0, personRepoMock.UpdateCallCount, "Update");
			Assert.AreEqual(0, personRepoMock.DeleteCallCount, "Delete");
		}

		[Test]
		public void DeletePresent()
		{
			var personRepoMock = new InstrumentedPersonWritableRepository();

			personRepoMock.Put(
				new Person
				{
					Id = -1,
					Version = 0,
					FirstName = "test",
					LastName = "person",
					Age = 42U
				}
			);

			Assert.AreEqual(0, personRepoMock.GetValuesCallCount, "GetValues before");
			Assert.AreEqual(1, personRepoMock.GetNextIdCallCount, "GetNextId before");
			Assert.AreEqual(1, personRepoMock.SaveCallCount, "Save before");
			Assert.AreEqual(0, personRepoMock.UpdateCallCount, "Update before");
			Assert.AreEqual(0, personRepoMock.DeleteCallCount, "Delete before");

			personRepoMock.Delete(1);

			Assert.AreEqual(1, personRepoMock.GetValuesCallCount, "GetValues");
			Assert.AreEqual(1, personRepoMock.GetNextIdCallCount, "GetNextId");
			Assert.AreEqual(1, personRepoMock.SaveCallCount, "Save");
			Assert.AreEqual(0, personRepoMock.UpdateCallCount, "Update");
			Assert.AreEqual(1, personRepoMock.DeleteCallCount, "Delete");
		}
	}
}
