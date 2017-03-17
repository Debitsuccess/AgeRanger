using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgeRanger.Models;

namespace AgeRanger.Repository
{
   public interface IPersonRepository
    {
        Task AddPerson(PersonModel person);
        Task<List<PersonModel>> GetAllPeople();
        Task<PersonModel> GetPerson(int Id);
        Task<bool> UpdatePerson(PersonModel person);
        Task<List<PersonModel>> SearchPeople(string searchText);
        Task DeleteAllUsers();
    }
}
