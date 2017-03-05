using System.Linq;

using WebApi.Domain;
using WebApi.Repositories;

namespace WebApi.Services
{
	public class AgeGroupService : IAgeGroupService
	{
		private readonly IRepository<int, AgeGroup> ageGroupRepository;


		public AgeGroupService(IRepository<int, AgeGroup> ageGroupRepository)
		{
			this.ageGroupRepository = ageGroupRepository;
		}


		public AgeGroup GetAgeGroup(uint age)
		{
			return ageGroupRepository.GetAll()
				.FirstOrDefault(ageGroup => ageGroup.ContainsAge(age));
		}
	}
}
