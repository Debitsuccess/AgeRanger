using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgeRanger.Controllers;
using AgeRanger.Models;
using System.Collections.Generic;

namespace AgeRanger.Tests
{
    [TestClass]
    public class AgeRangerControllerTest
    {
        private AgeRangerController _controller = new AgeRangerController();
        [TestMethod]
        public void GetAllPeople()
        {
            // Act
            List<Person> result = _controller.GetAll();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SearchPersonByLastName()
        {
            // Act
            var result = _controller.SearchByLastName("l1");

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void SearchPersonByFirstName()
        {
            // Act
            var result = _controller.SearchByFirstName("f1");

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetPersonById()
        {
            // Arrange
            int id = GetTestPersonId();

            // Act
            var result = _controller.GetPerson(id);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateAndDeletePerson()
        {
            //---Create---

            // Arrange
            var fisrtName = "cjtestF";
            var lastName = "cjtestL";
            var age = 22;
            Person person = new Person(fisrtName, lastName, age);

            // Act
           _controller.Create(person);
            List<Person> people = _controller.SearchByFirstName(fisrtName);

            // Assert
            Assert.IsNotNull(people);

            //---Delete---

            // Act
            foreach(Person p in people)
            {
                _controller.Delete(p.Id);
            }

            var valueAfterDelete = _controller.SearchByFirstName(fisrtName);
            // Assert
            Assert.AreEqual(0, valueAfterDelete.Count);
        }

        [TestMethod]
        public void UpdatePerson()
        {
            // Arrange
            var id = GetTestPersonId();
            Person person = _controller.GetPerson(id);
            person.FirstName = "updatedName";

            // Act
            _controller.Update(id, person);

            var value = _controller.GetPerson(id);
            // Assert
            Assert.IsNotNull(value);
            Assert.IsTrue(value.FirstName == "updatedName");
        }

        #region helper
        private int GetTestPersonId()
        {
            return 1;
        }
        #endregion
    }
}
