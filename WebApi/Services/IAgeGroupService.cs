using WebApi.Domain;

namespace WebApi.Services
{
	public interface IAgeGroupService
	{
		AgeGroup GetAgeGroup(uint age);
	}
}
