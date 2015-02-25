using System;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Core.Extensions
{
	public static class EnumExtensions
	{
		public static IEnumerable<T> GetValues<T>(this T @this) where T : struct
		{
			return Enum.GetValues(typeof(T)).Cast<T>().AsEnumerable<T>();
		}

		public static int ToInt(this Enum enumValue)
		{
			return Convert.ToInt32(enumValue);
		}
	}
}