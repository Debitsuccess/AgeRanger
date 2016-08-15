using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AgeRanger.Repository;
using AgeRanger.Models;
using System.Linq;

namespace AgeRanger.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IPersonRepository _ageRangerRepository;

        public PeopleController(IPersonRepository ageRangerRepository)
        {
            _ageRangerRepository = ageRangerRepository;
        }

        // GET api/people
        [HttpGet]
        public IEnumerable<PersonDto> Get()
        {
            return _ageRangerRepository.GetAll();
        }

        // GET api/people/id
        [HttpGet("{id}")]
        public PersonDto Get(int id)
        {
            return _ageRangerRepository.FindById(id).FirstOrDefault();
        }

        // GET api/people/GetByName/value
        [HttpGet("GetByName/{value}")]
        public IEnumerable<PersonDto> GetByName(string value)
        {
            return _ageRangerRepository.FindByValue(value);
        }

        // POST api/people
        [HttpPost]
        public void Post([FromBody]PersonDto person)
        {
            _ageRangerRepository.Add(new Person()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age
            });
                
        }

        // PUT api/people/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PersonDto person)
        {
            _ageRangerRepository.Update(person);
        }

        // DELETE api/people/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
