using AgeRanger.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace AgeRanger.Controllers
{
    public class PeopleController : ApiController
    {
        private AgeRangerEntities db = new AgeRangerEntities();
        private Models.IAgeRanger _ranger = null;

        public PeopleController()
        {
            _ranger = new Models.AgeRanger();
        }

        // GET: api/People/GetPeople
        public dynamic GetPeople(
                int sEcho,
                int iDisplayStart,
                int iDisplayLength,
                string sSearch,
                int iSortCol_0,
                string sSortDir_0)
        {
            var builder = new PeopleListBuilder(_ranger);
            var list = db.People.ToList();
            var models = builder.Build(list, iDisplayStart, iDisplayLength, iSortCol_0, sSortDir_0, sSearch);

            return new
            {
                recordsTotal = list.Count,
                recordsFiltered = list.Count,
                aaData = models.ToArray()
            };
        }

        // PUT: api/People/PutPerson/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerson(int id, PersonModel personModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = new Person { Id = personModel.Id, FirstName = personModel.FirstName, LastName = personModel.LastName, Age = personModel.Age };

            if (id != person.Id)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/People/PostPerson
        [ResponseType(typeof(PersonModel))]
        public IHttpActionResult PostPerson(PersonModel personModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = new Person { FirstName = personModel.FirstName, LastName = personModel.LastName, Age = personModel.Age };

            db.People.Add(person);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return db.People.Count(e => e.Id == id) > 0;
        }
    }
}