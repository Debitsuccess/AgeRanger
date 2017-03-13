using System.Collections.Generic;
using Infrastructure.Model;

namespace Infrastructure.IRepository
{
    public interface IPersonRepository
    {
        Person GetById(int id);

        IEnumerable<Person> GetAll();

        IEnumerable<Person> Search(string key);

        RepositoryActionResult<Person> Add(Person person);

        RepositoryActionResult<Person> Update(Person per);
    }
}
