using System.Linq;

namespace WebApi.Repositories
{
	public interface IRepository<in TKey, out TValue> where TValue : IRecord<TKey>
	{
		TValue Get(TKey id);
		IQueryable<TValue> GetAll();
	}
}
