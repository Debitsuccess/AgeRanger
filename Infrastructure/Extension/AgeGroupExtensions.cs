using System.Collections.Generic;
using System.Linq;
using Infrastructure.Model;

namespace Infrastructure.Extension
{
    public static class AgeGroupExtensions
    {
        public static AgeGroup GetAgeGroup(this List<AgeGroup> ageGroups, int age)
        {
            var ageGroup = new AgeGroup();

            var ageGroupWithMinAndMAx = ageGroups
                .Where(g => g.MinAge.HasValue && g.MaxAge.HasValue);

            foreach (var group in ageGroupWithMinAndMAx)
            {
                if (age >= group.MinAge && age < group.MaxAge)
                {
                    return group;
                }
            }

            var ageGroupWithMin = ageGroups
                .Where(g => g.MinAge.HasValue && !g.MaxAge.HasValue)
                .OrderByDescending(g => g.MinAge);

            foreach (var group in ageGroupWithMin)
            {
                if (age >= group.MinAge)
                {
                    return group;
                }
            }

            var ageGroupWithMAx = ageGroups
                .Where(g => !g.MinAge.HasValue && g.MaxAge.HasValue)
                .OrderBy(g => g.MaxAge);

            foreach (var group in ageGroupWithMAx)
            {
                if (age < group.MaxAge)
                {
                    return group;
                }
            }

            return ageGroup;
        }
    }
}
