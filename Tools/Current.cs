using System;

namespace Tools
{
	public static class Current
	{
		private static readonly Func<DateTimeOffset> DefaultGetUtcNow = () => DateTimeOffset.UtcNow;

		private static Func<DateTimeOffset> _getUtcNow = DefaultGetUtcNow;

		public static DateTimeOffset UtcNow => _getUtcNow();


		public static void FreezeUtcNow(DateTimeOffset? value = null)
		{
			var now = value ?? DateTimeOffset.UtcNow;
			_getUtcNow = () => now;
		}


		public static void Reset()
		{
			ResetUtcNow();
		}

		private static void ResetUtcNow()
		{
			_getUtcNow = DefaultGetUtcNow;
		}
	}
}
