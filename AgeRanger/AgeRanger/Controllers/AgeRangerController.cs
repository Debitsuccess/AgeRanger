using System;
using System.Net;
using System.Web.Http;
using AgeRanger.Models;
using AgeRanger.Services;
using AgeRanger.Utilities;
using System.Collections.Generic;

namespace AgeRanger.Controllers
{
    [RoutePrefix("people")]
    public class AgeRangerController : ApiController
    {
        private IAgeRangerService _ageRangerService = new AgeRangerService();

        [Route]
        [HttpGet]
        public List<Person> GetAll()
        {
            return _ageRangerService.GetAllPeople();
        }

        [Route]
        [HttpGet]
        public List<Person> SearchByFirstName(string firstName)
        {
            return _ageRangerService.SearchPersonByFirstName(firstName);
        }

        [Route]
        [HttpGet]
        public List<Person> SearchByLastName(string lastName)
        {
            return _ageRangerService.SearchPersonByLastName(lastName);
        }

        [Route("{id}")]
        [HttpGet]
        public Person GetPerson(int id)
        {
            return _ageRangerService.GetPersonById(id);
        }

        [Route]
        [HttpPost]
        public void Create(Person person)
        {
            try
            {
                _ageRangerService.AddPerson(person);
            }catch (Exception)
            {
                var response = HttpResponseFactory.ConstructResponse(HttpStatusCode.BadRequest, "Create new person failed, please check your input.");
                throw new HttpResponseException(response);
            }

        }

        [Route("{id}")]
        [HttpPut]
        public Person Update(int id, Person person)
        {
            if (person == null)
            {
                string errMessage = "Person cannot be null.";
                var response = HttpResponseFactory.ConstructResponse(HttpStatusCode.BadRequest, errMessage);
                throw new HttpResponseException(response);
            }
            return _ageRangerService.UpdatePerson(id, person);
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                _ageRangerService.DeletePerson(id);
            } catch (Exception)
            {
                var response = HttpResponseFactory.ConstructResponse(HttpStatusCode.BadRequest, "Delete failed, please try again.");
                throw new HttpResponseException(response);
            }

        }
    }
}
