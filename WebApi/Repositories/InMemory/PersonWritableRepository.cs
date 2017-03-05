using System.Collections.Generic;
using System.Linq;

using WebApi.Domain;

namespace WebApi.Repositories.InMemory
{
	public class PersonWritableRepository : BaseWritableRepository<int, Person>
	{
		private readonly Dictionary<int, Person> data = new Dictionary<int, Person>();


		protected override IQueryable<Person> GetValues()
		{
			return data.Values.AsQueryable();
		}

		protected override int GetNextId()
		{
			return (data.Count == 0)
				? 1
				: data.Keys.Max() + 1;
		}

		protected override void Save(Person value)
		{
			data.Add(value.Id, value);
		}

		protected override void Update(Person value)
		{
			data[value.Id] = value;
		}

		protected override void Delete(Person value)
		{
			data.Remove(value.Id);
		}
	}
}
