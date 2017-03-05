using System;

namespace WebApi.Repositories
{
	public interface IWritableRecord<T> : IRecord<T>
	{
		DateTimeOffset Created { get; }
		DateTimeOffset Modified { get; set; }
		uint Version { get; set; }
	}
}
