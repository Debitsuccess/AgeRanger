using System;

namespace WebApi.Repositories.Exceptions
{
	public class ConcurrentModificationException<TKey, TValue> : Exception where TValue : IWritableRecord<TKey>
	{
		public ConcurrentModificationException(TValue oldValue, TValue value) : base(MakeMessage(oldValue, value)) { }
// ReSharper disable once UnusedMember.Global
		public ConcurrentModificationException(TValue oldValue, TValue value, Exception inner) : base(MakeMessage(oldValue, value), inner) { }

		private static string MakeMessage(TValue oldValue, TValue value)
			=> $"Version clash: {oldValue.Version}@{oldValue.Modified} ({oldValue.Created}) vs {value.Version}@{value.Modified} ({value.Created})";
	}
}
