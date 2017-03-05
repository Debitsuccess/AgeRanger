using System.Collections.Generic;

using WebApi.Contracts;

namespace WebApi.Services
{
	public interface IPersonService
	{
		IEnumerable<Person> GetAllPeople();
		Person GetPerson(int id);

		void SaveNewPerson(Person person);
		void UpdatePerson(Person person);

		void RemovePerson(int id);
	}
}
