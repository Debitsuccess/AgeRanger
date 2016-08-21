using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AgeRanger.Repository;
using AgeRanger.Models;
using System.Linq;
using System;

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
        
        //POST api/people/personObject                
        [HttpPost]
        public ActionResult Post([FromBody]PersonDto person)
        {
            var errors = ValidatePerson(person);
            if (errors.Length > 0) return Json(errors);

            _ageRangerRepository.Add(new Person()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age
            });
            return Ok(person);
        }

        private string ValidatePerson(PersonDto person)
        {
            string errors = "";

            if (string.IsNullOrEmpty(person.FirstName)) errors += "FirstName is empty.";
            if (string.IsNullOrEmpty(person.LastName)) errors += "LastName is empty.";
            if (person.Age ==0) errors += "Age is not specified.";

            if (errors.Length > 0) return "Validation errors: " + errors;
            return errors;
        }

        //PUT api/people/personObject
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]PersonDto person)
        {
            var errors = ValidatePerson(person);
            if (errors.Length > 0) return Json(errors);

            _ageRangerRepository.Update(person);
            return Ok(person);
        }        
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException("Hasn't been implemented yet!");
        }        
    }
}
