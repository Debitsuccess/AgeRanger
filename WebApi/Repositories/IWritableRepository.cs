namespace WebApi.Repositories
{
	public interface IWritableRepository<TKey, TValue> : IRepository<TKey, TValue> where TValue : IRecord<TKey>
	{
		void Put(TValue value);
		void Delete(TKey key);
	}
}
