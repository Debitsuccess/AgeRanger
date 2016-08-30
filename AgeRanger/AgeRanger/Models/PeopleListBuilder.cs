using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeRanger.Models
{
    public class PeopleListBuilder
    {
        private IAgeRanger _ranger = null;

        public PeopleListBuilder(IAgeRanger ranger)
        {
            _ranger = ranger;
        }

        public List<PersonModel> Build(List<Person> peopleSet, int startRecord, int count, int sortCol, string sortDir, string searchString)
        {
            var list = peopleSet;
            if (!string.IsNullOrEmpty(searchString))
            {
                var stringsToCheck = new List<string> { searchString };
                list = peopleSet.Where(x => stringsToCheck.Any(str => FirstOrLastNameContains(x, str))).ToList();
            }

            switch (sortCol)
            {
                case 1:
                    list = sortDir == "asc" ? list.OrderBy(x => x.FirstName).ToList() : list.OrderByDescending(x => x.FirstName).ToList();
                    break;
                case 2:
                    list = sortDir == "asc" ? list.OrderBy(x => x.LastName).ToList() : list.OrderByDescending(x => x.LastName).ToList();
                    break;
                case 3:
                    list = sortDir == "asc" ? list.OrderBy(x => x.Age).ToList() : list.OrderByDescending(x => x.Age).ToList();
                    break;
            }

            var models = list.Select(x => new PersonModel { FirstName = x.FirstName, LastName = x.LastName, Age = x.Age, Id = x.Id, AgeGroup = _ranger.GetAgeDescription(x.Age) }).ToList();

            if (sortCol == 4)
            {
                models = sortDir == "asc" ? models.OrderBy(x => x.AgeGroup).ToList() : models.OrderByDescending(x => x.AgeGroup).ToList();
            }

            return count >= 0 ? models.Skip(startRecord).Take(count).ToList(): models.Skip(startRecord).ToList();
        }

        private bool FirstOrLastNameContains(Person person, string searchString)
        {
            return (
                (!string.IsNullOrEmpty(person.FirstName) && person.FirstName.ToLower().Contains(searchString.ToLower())) || 
                (!string.IsNullOrEmpty(person.LastName) && person.LastName.ToLower().Contains(searchString.ToLower())));
        }
    }
}