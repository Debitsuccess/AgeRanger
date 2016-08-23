using System.Collections.Generic;
using System.Web.Mvc;
using AgeRanger.Logic;
using Common.IoC;
using Entities;



namespace AgeRanger.Controllers
{
    public class PersonController : Controller
    {
        private IPersonRepository _personRepository = DependencyFactory.Resolve<IPersonRepository>();
        // GET: Person
        public ActionResult Index()
        {
            var personList = _personRepository.GetAllPersons();
            var ageGroupList = _personRepository.GetAllAgeGroups();

            var personAgeCategoryList = new List<Person>();
            foreach (var person in personList)
            {
                foreach (var age in ageGroupList)
                {
                    if (person.Age >= (age.MinAge != null ? age.MinAge : 0) 
                                && person.Age <= (age.MaxAge != null ? age.MaxAge : 0))
                        person.AgeGroupDescription = age.AgeGroupDescription;
                }
                personAgeCategoryList.Add(person);
            }
            
            return View(personAgeCategoryList);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person person)
        {
            try
            {
                _personRepository.SavePerson(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            var personInfo = _personRepository.GetPersonById(id);
            return View(personInfo);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person person)
        {
            try
            {
                _personRepository.SavePerson(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
