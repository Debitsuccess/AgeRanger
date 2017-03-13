using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using AgeRanger.DTO;
using Infrastructure;
using Infrastructure.Factories;
using Infrastructure.IRepository;
using Infrastructure.IService;

namespace AgeRanger.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class PersonController : ApiController
    {
        private readonly PersonFactory _personFactory = new PersonFactory();
        private readonly IPersonRepository _personRepository;
        private readonly IPersonService _personService;

        public PersonController(
            IPersonRepository personRepository,
            IPersonService personService)
        {
            _personRepository = personRepository;
            _personService = personService;
        }

        [Route("search")]
        [HttpGet]
        public IHttpActionResult Search([FromUri]SearchModel search)
        { 
            try
            {
                if(search == null)
                {
                    return BadRequest();
                }

                var persons = _personRepository
                    .Search(search.Key)
                    .ToList();

               var people = persons
                    .Select(p => _personFactory.CreatePersonView(p));

                return Ok(people);
            }
            catch (Exception)
            {
                //Log error
                return InternalServerError();
            }
        }

        [Route("people")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var people = _personRepository
                    .GetAll()
                    .Select(p => _personFactory.CreatePersonView(p));

                return Ok(people);
            }
            catch (Exception)
            {
                // Log error
                return InternalServerError();
            }
        }

        [Route("person/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var person = _personRepository
                    .GetById(id);

                if (person == null)
                {
                    return NotFound();
                }

                return Ok(_personFactory.CreatePersonView(person));
            }
            catch (Exception)
            {
                // Log error
                return InternalServerError();
            }
        }

        [Route("person/{id}")]
        [AcceptVerbs("Put")]
        public IHttpActionResult Put(int id,[FromBody]PersonViewModel person)
        {
            try
            {
                if (person == null)
                {
                    return BadRequest();
                }

                var result = _personService.Update(person);

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    return Ok(_personFactory.CreatePersonView(result.Entity));
                }
                if (result.Status == RepositoryActionStatus.NotFound)
                {
                    return NotFound();
                }

                return BadRequest();
            }
            catch (Exception)
            {
                //Log error
                return InternalServerError();
            }
        }

        [Route("person")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Post([FromBody]PersonViewModel person)
        {
            try
            {
                if (person == null)
                {
                    return BadRequest();
                }

                var result = _personService.Add(person);

                if (result.Status == RepositoryActionStatus.Created)
                {
                    var newPerson = _personFactory.CreatePersonView(result.Entity);
                    return Created(Request?.RequestUri + "/" + newPerson.Id, newPerson);
                }

                return BadRequest();

            }
            catch (Exception)
            {
                //Log error
                return InternalServerError();
            }
        }
    }
}