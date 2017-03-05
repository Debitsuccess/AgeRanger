using System.Linq;

using NUnit.Framework;

using WebApi.Domain;
using WebApi.Repositories.InMemory;

namespace WebApi.Tests.Repositories.InMemory
{
	[TestFixture]
	public class AgeGroupRepositoryTests
	{
		private class InstrumentedAgeGroupRepository : AgeGroupRepository
		{
			public uint ReadEntireCollectionCallCount;

			protected override IQueryable<AgeGroup> ReadEntireCollection()
			{
				ReadEntireCollectionCallCount++;
				return base.ReadEntireCollection();
			}
		}


		[Test]
		public void RepoCachesGetAll()
		{
			var repo = new InstrumentedAgeGroupRepository();

			Assert.AreEqual(0U, repo.ReadEntireCollectionCallCount, "Before");
			repo.GetAll();
			Assert.AreEqual(1U, repo.ReadEntireCollectionCallCount, "During");
			repo.GetAll();
			Assert.AreEqual(1U, repo.ReadEntireCollectionCallCount, "After");
		}
	}
}
