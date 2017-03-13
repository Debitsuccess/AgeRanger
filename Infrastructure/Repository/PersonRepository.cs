using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Infrastructure.Extension;
using Infrastructure.IRepository;
using Infrastructure.Model;
using Infrastructure.Service;

namespace Infrastructure.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AgeRangerContext _db;

        public PersonRepository(AgeRangerContext db)
        {
            _db = db;
        }

        public Person GetById(int id)
        {
            return _db
                .Persons
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return _db
                .Persons
                .ToList();
        }

        public IEnumerable<Person> Search(string key)
        {
            return _db
                .Persons
                .Where(p => p.FirstName.Contains(key) ||
                            p.LastName.Contains(key))
                .ToList();
        }

        public RepositoryActionResult<Person> Add(Person person)
        {
            try
            {
                person.AgeGroup = _db
                    .AgeGroups
                    .ToList()
                    .GetAgeGroup(person.Age);

                _db.Persons.Add(person);

                var result = _db.SaveChanges();

                if (result > 0)
                {
                    return new RepositoryActionResult<Person>(person, RepositoryActionStatus.Created);
                }

                return new RepositoryActionResult<Person>(person, RepositoryActionStatus.NothingModified, null);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Person>(null, RepositoryActionStatus.Error, ex);
            }
        }

        public RepositoryActionResult<Person> Update (Person person)
        {
            var ageGroup = _db
                .AgeGroups
                .ToList()
                .GetAgeGroup(person.Age);

            person.AgeGroupId = ageGroup.Id;

            var existingPerson = _db
                .Persons
                .FirstOrDefault(p => p.Id == person.Id);

            if (existingPerson == null)
            {
                return new RepositoryActionResult<Person>(person, RepositoryActionStatus.NotFound);
            }

            // change the original entity status to detached; otherwise, we get an error on attach
            // as the entity is already in the dbSet

            // set original entity state to detached
            _db.Entry(existingPerson).State = EntityState.Detached;

            // attach & save
            _db.Persons.Attach(person);

            // set the updated entity state to modified, so it gets updated.
            _db.Entry(person).State = EntityState.Modified;

            var result = _db.SaveChanges();

            return result > 0
                ? new RepositoryActionResult<Person>(person, RepositoryActionStatus.Updated)
                : new RepositoryActionResult<Person>(person, RepositoryActionStatus.NothingModified, null);
        }
    }
}