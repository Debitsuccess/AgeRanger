using AgeRanger.DTO;
using Person = Infrastructure.Model.Person;

namespace Infrastructure.Factories
{
    public class PersonFactory
    {
        public Person CreatePerson(PersonViewModel person)
        {
            return new Person
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age
            };
        }

        public PersonViewModel CreatePersonView(Person person)
        {
            return new PersonViewModel
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age,
                AgeGroup = person.AgeGroup?.Description
            };
        }
    }
}
