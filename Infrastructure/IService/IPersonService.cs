using AgeRanger.DTO;
using Infrastructure.Model;

namespace Infrastructure.IService
{
    public interface IPersonService
    {
        RepositoryActionResult<Person> Add(PersonViewModel person);

        RepositoryActionResult<Person> Update(PersonViewModel person);
    }
}
