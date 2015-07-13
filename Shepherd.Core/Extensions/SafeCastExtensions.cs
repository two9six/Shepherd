using System;

namespace Shepherd.Core.Extensions
{
	public static class SafeCastExtensions
	{
		public static int ToSafeInt(this string value)
		{
			int result = 0;
			int.TryParse(value, out result);
			return result;
		}

		public static DateTime ToSafeDateTime(this string value)
		{
			var result = DateTime.MinValue;
			DateTime.TryParse(value, out result);
			return result;
		}
	}
}