using System.Collections.Generic;
using System.Linq;

using WebApi.Domain;

namespace WebApi.Repositories.InMemory
{
	public class AgeGroupRepository : BaseCacheAllRepository<int, AgeGroup>
	{
		private readonly Dictionary<int, AgeGroup> data = new Dictionary<int, AgeGroup>
		{
			{ 1, new AgeGroup { Id = 1, MinAge = null, MaxAge = 2, Description = "Toddler" } },
			{ 2, new AgeGroup { Id = 2, MinAge = 2, MaxAge = 14, Description = "Child" } },
			{ 3, new AgeGroup { Id = 3, MinAge = 14, MaxAge = 20, Description = "Teenager" } },
			{ 4, new AgeGroup { Id = 4, MinAge = 20, MaxAge = 25, Description = "Early twenties" } },
			{ 5, new AgeGroup { Id = 5, MinAge = 25, MaxAge = 30, Description = "Almost thirty" } },
			{ 6, new AgeGroup { Id = 6, MinAge = 30, MaxAge = 50, Description = "Very adult" } },
			{ 7, new AgeGroup { Id = 7, MinAge = 50, MaxAge = 70, Description = "Kinda old" } },
			{ 8, new AgeGroup { Id = 8, MinAge = 70, MaxAge = 99, Description = "Old" } },
			{ 9, new AgeGroup { Id = 9, MinAge = 99, MaxAge = 110, Description = "Very old" } },
			{ 10, new AgeGroup { Id = 10, MinAge = 110, MaxAge = 199, Description = "Crazy ancient" } },
			{ 11, new AgeGroup { Id = 11, MinAge = 199, MaxAge = 4999, Description = "Vampire" } },
			{ 12, new AgeGroup { Id = 12, MinAge = 4999, MaxAge = null, Description = "Kauri tree" } }
		};

		protected override IQueryable<AgeGroup> ReadEntireCollection()
		{
			return data.Values.AsQueryable();
		}
	}
}
