using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeRanger.Models
{
    public class AgeRanger : IAgeRanger
    {
        private List<AgeGroup> _groups;

        public AgeRanger()
        {
            var db = new AgeRangerEntities();
            _groups = db.AgeGroups.ToList();
        }

        internal AgeRanger(List<AgeGroup> groups)
        {
            _groups = groups;
        }

        public string GetAgeDescription(int age)
        {
            var description = "unknown";
            if (age >= 0)
            {
                foreach (var g in _groups)
                {
                    if ((!g.MinAge.HasValue || age >= g.MinAge.Value) && (!g.MaxAge.HasValue || age < g.MaxAge.Value))
                    {
                        description = g.Description;
                        break;
                    }
                }
            }
            return description;
        }
    }
}