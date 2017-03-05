using System.Linq;

using Moq;

using NUnit.Framework;

using WebApi.Domain;
using WebApi.Repositories;
using WebApi.Services;

namespace WebApi.Tests.Services
{
	[TestFixture]
	public class AgeGroupServiceTests
	{
		[Test]
		public void GetAgeGroupCallsContainsAge()
		{
			const uint AGE = 42U;

			var ageGroupMock = new Mock<AgeGroup>();
			ageGroupMock.Setup(ageGroup => ageGroup.ContainsAge(AGE))
				.Returns(true)
				.Verifiable();

			var repositoryMock = new Mock<IRepository<int, AgeGroup>>();
			repositoryMock.Setup(repo => repo.GetAll())
				.Returns(new[] { ageGroupMock.Object }.AsQueryable)
				.Verifiable();

			var service = new AgeGroupService(repositoryMock.Object);


			var result = service.GetAgeGroup(AGE);


			ageGroupMock.VerifyAll();
			repositoryMock.VerifyAll();
			Assert.AreEqual(ageGroupMock.Object, result);
		}
	}
}
