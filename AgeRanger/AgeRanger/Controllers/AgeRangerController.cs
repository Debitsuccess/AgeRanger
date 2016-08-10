using System;
using System.Net;
using System.Web.Http;
using AgeRanger.Models;
using System.Collections.Generic;

namespace AgeRanger.Controllers
{
    [RoutePrefix("people")]
    public class AgeRangerController : ApiController
    {

        [Route]
        [HttpGet]
        public List<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        [Route]
        [HttpGet]
        public List<Person> SearchByFirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        [Route]
        [HttpGet]
        public List<Person> SearchByLastName(string lastName)
        {
            throw new NotImplementedException();
        }

        [Route("{id}")]
        [HttpGet]
        public Person GetPerson(int id)
        {
            throw new NotImplementedException();
        }

        [Route]
        [HttpPost]
        public void Create(Person person)
        {
            throw new NotImplementedException();
        }

        [Route("{id}")]
        [HttpPut]
        public void Update(int id, Person person)
        {
            throw new NotImplementedException();
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
