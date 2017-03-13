using AgeRanger.DTO;
using Infrastructure.Factories;
using Infrastructure.IRepository;
using Infrastructure.IService;
using Infrastructure.Model;

namespace Infrastructure.Service.AgeRanger
{
    public class PersonService : IPersonService
    {
        private readonly PersonFactory _personFactory = new PersonFactory();
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public RepositoryActionResult<Person> Add(PersonViewModel person)
        {
            var personCreateData = _personFactory
                .CreatePerson(person);

            return _personRepository
                .Add(personCreateData);
        }

        public RepositoryActionResult<Person> Update(PersonViewModel person)
        {
            var personCreateData = _personFactory
                .CreatePerson(person);

            return _personRepository
                .Update(personCreateData);
        }
    }
}
