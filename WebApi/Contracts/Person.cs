using System;

namespace WebApi.Contracts
{
	public class Person
	{
		public int Id;

		public DateTimeOffset Created;
		public DateTimeOffset Modified;
		public uint Version;

		public string FirstName;	//TODO: validation attrs once I pick the frontEnd tech...
		public string LastName;
		public uint Age;

		public string AgeGroup;
	}
}
