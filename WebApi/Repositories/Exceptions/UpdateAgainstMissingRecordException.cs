using System;

namespace WebApi.Repositories.Exceptions
{
	public class UpdateAgainstMissingRecordException<TKey, TValue> : Exception where TValue : IWritableRecord<TKey>
	{
		public UpdateAgainstMissingRecordException(TValue value) : base(MakeMessage(value)) { }
// ReSharper disable once UnusedMember.Global
		public UpdateAgainstMissingRecordException(TValue value, Exception inner) : base(MakeMessage(value), inner) { }

		private static string MakeMessage(TValue value)
			=> $"Update: [{value.Id}]{value.Version}@{value.Modified} ({value.Created})";
	}
}
