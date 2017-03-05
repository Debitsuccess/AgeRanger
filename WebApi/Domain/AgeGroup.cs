using WebApi.Repositories;

namespace WebApi.Domain
{
	public class AgeGroup : IRecord<int>
	{
		public int Id { get; set; }

		public uint? MinAge { get; set; }
		public uint? MaxAge { get; set; }

		public string Description { get; set; }


		//NOTE: This leverages the property of compares against null Nullable<> values always resolving to false:
		// Only virtual for unit tests:
		public virtual bool ContainsAge(uint age) => !(age < MinAge || age >= MaxAge);
	}
}
