using System;

namespace Shepherd.Core.Extensions
{
	public static class SafeStringCastExtensions
	{
		public static string TryGetString(this DateTime? value)
		{
			if (value == null)
				return string.Empty;

			return value.ToString();
		}
	}
}