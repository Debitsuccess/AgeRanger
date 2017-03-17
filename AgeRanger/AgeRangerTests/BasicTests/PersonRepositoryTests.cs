using System;
using System.Threading.Tasks;
using AgeRanger.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgeRangerTests.BasicTests
{
    [TestClass]
    public class PersonRepositoryTests
    {
        [TestMethod]


        public async Task Test_GetPerson()
        {
            //Arrange
            PersonRepository repo = new PersonRepository();

            //Act
           var person = await repo.GetPerson(-1);

            //Assert
            Assert.IsTrue(person.Id == 0);
        }
    }
}
