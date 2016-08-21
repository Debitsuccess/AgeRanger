using AgeRanger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgeRanger.Repository
{
    public class PersonRepository : IPersonRepository
    {
        protected Microsoft.EntityFrameworkCore.DbContext _entities; 
        private readonly AgeRangerContext _ageRangerContext;
        private readonly IQueryable<Person> _personQuery;

        public PersonRepository(AgeRangerContext ageRangerContext)
        {
            _ageRangerContext = ageRangerContext;
            _personQuery = _ageRangerContext.Set<Person>();
        }

        public void Add(Person item)
        {           
            _ageRangerContext.Add(item);
            _ageRangerContext.SaveChanges();
        }

        public IEnumerable<PersonDto> FindByValue(string value)
        {
            if (value.Length == 0)
                return MapPersonToDto(_personQuery);             

            var selected = _personQuery.Where(x => x.FirstName.Contains(value) || x.LastName.Contains(value));
            return MapPersonToDto(selected);
        }

        public IEnumerable<PersonDto> FindById(int id)
        {
            var selected = _personQuery.Where(x=>x.Id == id);
            return MapPersonToDto(selected);
        }

        public IEnumerable<PersonDto> MapPersonToDto(IQueryable<Person> selected)
        {
            List<PersonDto> listOfPeople = new List<PersonDto>(selected.Count());
            var ageGroups = _ageRangerContext.AgeGroup;

            foreach (var person in selected)
            {
                var currentAge = person.Age;
                var currentAgeGroup = ageGroups.Where(x=>x.MinAge <= person.Age && x.MaxAge> person.Age).FirstOrDefault();

                listOfPeople.Add(new PersonDto()
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Age = person.Age,
                    AgeGroup = currentAgeGroup.Description
                });
            }
            return listOfPeople;
        }

        public Person MapDtoToPerson(PersonDto personDto)
        {
            var existingRecord = _personQuery.Where(x => x.Id == personDto.Id).FirstOrDefault();

            existingRecord.FirstName = personDto.FirstName;
            existingRecord.LastName = personDto.LastName;
            existingRecord.Age = personDto.Age;

            return existingRecord;
        }

        public IEnumerable<PersonDto> FindBy(Expression<Func<Person, bool>> predicate)
        {                       
            var selected = _personQuery.Where(predicate);
            return MapPersonToDto(selected);
        }

        public IEnumerable<PersonDto> GetAll()
        {            
            var people = _ageRangerContext.Person;
            return MapPersonToDto(people);
        }

        public void Remove(PersonDto item)
        {
            var person = _personQuery.Where(x => x.Id == item.Id).FirstOrDefault();
            _ageRangerContext.Person.Remove(person);
            _ageRangerContext.SaveChanges();
        }

        public void Update(PersonDto item)
        {
            var person = MapDtoToPerson(item);
            _ageRangerContext.Person.Update(person);
            _ageRangerContext.SaveChanges();
        }
    }
}
