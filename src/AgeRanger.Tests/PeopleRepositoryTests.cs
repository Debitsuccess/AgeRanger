using AgeRanger.Controllers;
using AgeRanger.Models;
using AgeRanger.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AgeRanger.Tests
{
    public class PeopleRepositoryTests
    {
        private IServiceProvider serviceProvider;

        public IConfigurationRoot Configuration { get; }

        private readonly AgeRangerContext _ageRangerContext;
        private readonly IPersonRepository _peopleRepository;

        public PeopleRepositoryTests()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            AgeRangerContext ageRangerContext = new AgeRangerContext(Configuration);            
            SetupData(ageRangerContext);
            _ageRangerContext = ageRangerContext;
            _peopleRepository = new PersonRepository(_ageRangerContext);
        }

        private IEnumerable<Person> FetchListOfPeople()
        {
            return new List<Person>
            {
                new Person()
                {
                    FirstName = "Erich",
                    LastName = "Gamma",
                    Age = 55
                },
                new Person()
                {
                    FirstName = "Richard",
                    LastName = "Helm",
                    Age = 45
                },
                new Person()
                {
                    FirstName = "Ralph",
                    LastName = "Johnson",
                    Age = 70
                }
            };
        }

        private IEnumerable<AgeGroup> FetchListOfAgeGroups()
        {
            return new List<AgeGroup>()
            {
                new AgeGroup
                {                    
                    MinAge = 35,
                    MaxAge = 55,
                    Description = "Adult"
                },
                new AgeGroup
                {                    
                    MinAge = 55,
                    MaxAge = 80,
                    Description = "Senior"
                }
            };
        }

        public void SetupData(AgeRangerContext dbContext)
        {
            CleanUp(dbContext);

            foreach (var person in FetchListOfPeople())
            {
                dbContext.Person.Add(person);
            }
            foreach (var ageGroup in FetchListOfAgeGroups())
            {
                dbContext.AgeGroup.Add(ageGroup);
            }
            dbContext.SaveChanges();
        }

        public void CleanUp(AgeRangerContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();
            dbContext.AgeGroup.RemoveRange(dbContext.AgeGroup);
            dbContext.Person.RemoveRange(dbContext.Person);
            dbContext.SaveChanges();
        }

        [Fact]
        public void TestGet()
        {          
            var people = _peopleRepository.GetAll();
            Assert.Equal(people.Count(), 3);
        }

        [Fact]
        public void TestAdd()
        {            
            var peopleCountBefore = _peopleRepository.GetAll().Count();
            _peopleRepository.Add(new Person() {FirstName ="John", LastName ="Key", Age=55 });
            var peopleCountAfter = _peopleRepository.GetAll().Count();
            Assert.Equal(peopleCountAfter, peopleCountBefore + 1);            
        }

        [Fact]
        public void TestRemove()
        {            
            var peopleCountBefore = _peopleRepository.GetAll().Count();
            _peopleRepository.Add(new Person() { FirstName = "John", LastName = "Key", Age = 55 });
            var personToDelete = _peopleRepository.FindByValue("Key");
            _peopleRepository.Remove(personToDelete.First());
            var peopleCountAfter = _peopleRepository.GetAll().Count();
            Assert.Equal(peopleCountBefore, peopleCountAfter);
        }

        [Fact]
        public void TestUpdate()
        {
            var personToUpdate = new Person() { FirstName = "John", LastName = "Key", Age = 55 };
            _peopleRepository.Add(personToUpdate);
            var insertedPersonRecord = _peopleRepository.FindByValue(personToUpdate.LastName).First();

            insertedPersonRecord.LastName = "Key II";
            _peopleRepository.Update(insertedPersonRecord);

            var updatedPersonRecord = _peopleRepository.FindByValue(personToUpdate.LastName).First();
            Assert.Equal(insertedPersonRecord.LastName, updatedPersonRecord.LastName);
        }

        [Fact]
        public void TestFindByValue()
        {
            var person = _peopleRepository.FindByValue("John");
            Assert.Equal(person.Count(), 1);
        }
    }
}

