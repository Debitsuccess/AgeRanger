
using System.Collections.Generic;
using Entities;

namespace AgeRanger.Logic
{
    public interface IDataBaseCommonFactory
    {
        void SavePerson(Person person);

        Person GetPersonById(int id);

        List<AgeGroup> GetAllAgeGroups();

        List<Person> GetAllPersons();
    }
}
