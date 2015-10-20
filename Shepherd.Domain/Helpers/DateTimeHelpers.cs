using System;

namespace Shepherd.Domain.Helpers
{
	public static class DateTimeHelpers
	{
		public static int ComputeAge(DateTime dateOfBirth)
		{
			var now = DateTime.Today;
			var age = now.Year - dateOfBirth.Year;

			if (now < dateOfBirth.AddYears(age))
			{
				age--;
			}

			return age;
		}

		public static int ComputeAgeCelebrant(DateTime dateOfBirth)
		{
			var now = new DateTime(DateTime.Now.Year,
				DateTime.Now.Month,
				DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 23, 59, 59);
			var age = now.Year - dateOfBirth.Year;

			if (now < dateOfBirth.AddYears(age))
			{
				age--;
			}

			return age;
		}
	}
}
