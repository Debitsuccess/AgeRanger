using AgeRanger.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Configuration;
using Common.IoC;

namespace AgeRanger.Service
{
    public class PersonRepository : IPersonRepository
    {
        private IDataBaseCommonFactory _dbRepositoryInstance 
                = new DataBaseCreationFactory().GetInstance(ConfigurationManager.AppSettings["DataBaseType"]);

        public List<AgeGroup> GetAllAgeGroups()
        {
            return _dbRepositoryInstance.GetAllAgeGroups();
        }

        public List<Person> GetAllPersons()
        {
            return _dbRepositoryInstance.GetAllPersons();
        }

        public Person GetPersonById(int id)
        {
            throw new NotImplementedException();
        }

        public void SavePerson(Person person)
        {
            _dbRepositoryInstance.SavePerson(person);
        }
    }
}
