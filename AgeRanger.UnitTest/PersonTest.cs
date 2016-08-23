using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using AgeRanger.Logic;
using Entities;
using Common.IoC;
using Microsoft.Practices.Unity;
using AgeRanger.Service;

namespace AgeRanger.UnitTest
{
    public class PersonTest
    {
        [TestCase]
        public void GetAllPersonTest()
        {
            //Arange
            var mockPersonRepository = new Mock<IPersonRepository>();
            mockPersonRepository.Setup(I => I.GetPersonById(It.IsAny<int>()))
                .Returns(new Person()
                {
                    Id = 1,
                    FirstName = "Niel",
                    LastName = "Perera",
                    Age = 30
                });

            DependencyFactory.Container.RegisterInstance(mockPersonRepository);

            //Act
            var personRepository = new PersonRepository();
            var personTest = personRepository.GetPersonById(1);

            //Assert
            Assert.AreEqual(personTest.Id, 1);
            Assert.AreEqual(personTest.FirstName, "Niel");
        }
    }
}
