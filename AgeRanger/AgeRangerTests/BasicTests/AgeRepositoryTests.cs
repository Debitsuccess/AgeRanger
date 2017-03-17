using System;
using AgeRanger.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgeRangerTests.BasicTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_GetAllAgeGroups()
        {

            //Arrange
            AgeGroupRepository repo = new AgeGroupRepository();

            //Assert
            var result = repo.GetAllAgeGroups();

            //Act
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 5);

        }
    }
}
