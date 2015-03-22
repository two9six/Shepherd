using System;

namespace Shepherd.Core.Helpers
{
	public static class DateTimeHelpers
	{
		public static int ComputeAge(DateTime dateOfBirth)
		{
			DateTime now = DateTime.Today;
			int age = now.Year - dateOfBirth.Year;

			if (now < dateOfBirth.AddYears(age))
			{
				age--;
			}

			return age;
		}
	}
}
