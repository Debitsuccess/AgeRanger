using System.Linq;

namespace WebApi.Repositories.InMemory
{
	public abstract class BaseCacheAllRepository<TKey, TValue> : IRepository<TKey, TValue> where TValue : IRecord<TKey>
	{
		private IQueryable<TValue> allValues;


		public TValue Get(TKey id)
		{
			return GetAll()
				.FirstOrDefault(value => value.Id.Equals(id));
		}

		public IQueryable<TValue> GetAll()
		{
			return allValues ?? (allValues = ReadEntireCollection());
		}


		protected abstract IQueryable<TValue> ReadEntireCollection();
	}
}
