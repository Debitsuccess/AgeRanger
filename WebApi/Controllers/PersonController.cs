using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using WebApi.Contracts;
using WebApi.Services;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	public class PersonController : Controller
	{
		private readonly IPersonService personService;


		public PersonController(IPersonService personService)
		{
			this.personService = personService;
		}


		// GET api/person
		[HttpGet]
		public IEnumerable<Person> Get()
		{
			return personService.GetAllPeople();
		}


		// GET api/person/5
		[HttpGet("{id}")]
		public Person Get(int id)
		{
			return personService.GetPerson(id);
		}

		// POST api/person
		[HttpPost]
		public void Post([FromBody] Person person)
		{
			personService.SaveNewPerson(person);
		}


		// PUT api/person/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] Person person)
		{
			person.Id = id;
			personService.UpdatePerson(person);
		}


		// DELETE api/person/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			personService.RemovePerson(id);
		}
	}
}
