using System;

using Tools;

using WebApi.Repositories;

namespace WebApi.Domain
{
	public class Person : IWritableRecord<int>
	{
		public Person()
		{
			Created = Current.UtcNow;
			Modified = Created;
			Version = 0;
		}


		public int Id { get; set; }

		public DateTimeOffset Created { get; set; }
		public DateTimeOffset Modified { get; set; }
		public uint Version { get; set; }


		public string FirstName { get; set; }
		public string LastName { get; set; }

		public uint Age { get; set; }
	}
}
