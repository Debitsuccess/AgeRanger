using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AgeRanger.Models;
using AgeRanger.Repository;

namespace AgeRanger.Controllers
{
    [RoutePrefix("api/ageranger")]
    public class AgeRangerController : ApiController
    {

        IPersonRepository _PersonRepository;
        IAgeGroupRepository _AgeGroupRepository;
        public AgeRangerController()

        {
            this._PersonRepository = new PersonRepository();
            this._AgeGroupRepository = new AgeGroupRepository();
        }

        [Route("search/{searchText}")]
        [HttpGet]
        public async Task<List<PersonModel>> GetSearch(string searchText)

        {
            var allPeople = await _PersonRepository.SearchPeople(searchText);
            this.GetAgeGroups(ref allPeople);
            return allPeople;
        }


        [Route("people")]
        [HttpGet]
        public async Task<List<PersonModel>> GetPeople()
        {
            //await _PersonRepository.DeleteAllUsers();
            var allPeople = (await _PersonRepository.GetAllPeople()).OrderBy(x => x.Age).ToList();
          
            this.GetAgeGroups(ref allPeople);
            return allPeople;
        }

        [Route("delete")]
        [HttpDelete]
        public async Task DeletePeople()
        {
            await _PersonRepository.DeleteAllUsers();


        }

        [Route("person/{Id}")]
        [HttpGet]
        public async Task<PersonModel> GetPerson(int Id)
        {
           var person = await _PersonRepository.GetPerson(Id);

            return person;
        }

        [HttpPost]
        public async Task PostPerson( PersonModel person)
        {
            if (person.Id > 0)
            {
                //Update
                await _PersonRepository.UpdatePerson(person);

            }
            else
            {
                //Add
                await _PersonRepository.AddPerson(person);
            }


        }

        private void GetAgeGroups(ref List<PersonModel> allPeople)
        {
            var allAgeGroups = _AgeGroupRepository.GetAllAgeGroups();
            allPeople.ForEach(person =>
            {
                foreach (var ageGroup in allAgeGroups)
                {
                    if (person.Age >= ageGroup.MinAge & person.Age < ageGroup.MaxAge)
                    {
                        person.AgeGroup = String.Format("Between {0} and {1} (age group)", ageGroup.MinAge, ageGroup.MaxAge);
                        break;
                    }
                }
            });

        }
    }
}
