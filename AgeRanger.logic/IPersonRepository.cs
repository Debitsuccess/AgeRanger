using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.Logic
{
    public interface IPersonRepository
    {
        void SavePerson(Person person);

        Person GetPersonById(int id);

        List<AgeGroup> GetAllAgeGroups();

        List<Person> GetAllPersons();
    }
}
