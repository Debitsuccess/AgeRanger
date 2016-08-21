using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using AgeRanger.Repository;
using AgeRanger.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Moq;
using Xunit;
using AgeRanger.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AgeRanger.Tests
{
    public class PeopleControllerTests
    {
        private readonly IServiceProvider serviceProvider;          
        
        [Fact]
        public void TestGetAll()
        {
            Mock<IPersonRepository> peopleRepository = new Mock<IPersonRepository>();
            peopleRepository.Setup(x => x.GetAll()).Returns(FetchListOfPeopleDto());
            var peopleController = new PeopleController(peopleRepository.Object);
            var people = peopleController.Get();

            Assert.Equal(people.Count(), 3);
        }

        [Fact]
        public void TestAdd()
        {
            Mock<IPersonRepository> peopleRepository = new Mock<IPersonRepository>();
            var peopleController = new PeopleController(peopleRepository.Object);
            var testPerson = FetchOnePersonDto().First();
            var result = peopleController.Post(testPerson);

            Assert.Equal(result.GetType(), typeof(OkObjectResult));
        }

        [Fact]
        public void TestFindByName()
        {
            var searchString = "John";
            Mock<IPersonRepository> peopleRepository = new Mock<IPersonRepository>();
            peopleRepository.Setup(x => x.FindByValue(searchString)).Returns(FetchOnePersonDto());

            var peopleController = new PeopleController(peopleRepository.Object);

            var result = peopleController.GetByName(searchString);

            Assert.Equal(result.Count(), 1);
            Assert.Equal(result.First().FirstName, searchString);
        }

        [Fact]
        public void TestUpdate()
        {
            Mock<IPersonRepository> peopleRepository = new Mock<IPersonRepository>();
            var personToUpdate = FetchOnePersonDto();
            var personId = Convert.ToInt32(personToUpdate.First().Id);

            peopleRepository.Setup(x => x.FindById(personId)).Returns(personToUpdate);

            var peopleController = new PeopleController(peopleRepository.Object);
            ActionResult result = peopleController.Put(personId, personToUpdate.First());

            Assert.Equal(result.GetType(), typeof(OkObjectResult));
        }

        public static IEnumerable<PersonDto> FetchListOfPeopleDto()
        {
            return new List<PersonDto>
            {
                new PersonDto()
                {
                    FirstName = "Erich",
                    LastName = "Gamma",
                    Age = 55,
                    AgeGroup = "Adult"
                },
                new PersonDto()
                {
                    FirstName = "Richard",
                    LastName = "Helm",
                    Age = 45,
                    AgeGroup = "Adult"
                },
                new PersonDto()
                {
                    FirstName = "Ralph",
                    LastName = "Johnson",
                    Age = 70,
                    AgeGroup = "Senior"
                }
            };
        }

        private IEnumerable<PersonDto> FetchOnePersonDto()
        {
            return new List<PersonDto> {
                new PersonDto()
                {
                    FirstName = "John",
                    LastName = "Key",
                    Age = 55,
                    AgeGroup = "Adult"
                }
            };
        }

        private IEnumerable<Person> FetchOnePerson()
        {
            return new List<Person>()
            {
                new Person() {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Key",
                    Age = 55
                }
            };
        }

    }
}
