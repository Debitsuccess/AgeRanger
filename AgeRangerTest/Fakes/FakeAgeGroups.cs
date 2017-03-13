using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Model;

namespace AgeRangerTest.Fakes
{
    public static class FakeAgeGroups
    {
        public static IEnumerable<AgeGroup> AgeGroups = new List<AgeGroup>
        {
            new AgeGroup
            {
                Id = 1,
                MinAge = 0,
                MaxAge = 100,
                Description = "Old"
            }
        }
        .AsEnumerable();
    }
}
