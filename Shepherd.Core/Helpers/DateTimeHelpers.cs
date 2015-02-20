using System;

namespace Shepherd.Core.Helpers
{
	public static class DateTimeHelpers
	{
		public static int ComputeAge(DateTime birthday)
		{
			DateTime now = DateTime.Today;
			int age = now.Year - birthday.Year;

			if (now < birthday.AddYears(age))
			{
				age--;
			}

			return age;
		}
	}
}
