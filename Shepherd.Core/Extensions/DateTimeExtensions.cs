using System;
using System.Web.Mvc;

namespace Shepherd.Core.Extensions
{
	public static class DateTimeExtensions
	{
		public static string Age(this HtmlHelper helper, DateTime birthday)
		{
			DateTime now = DateTime.Today;
			int age = now.Year - birthday.Year;
			if (now < birthday.AddYears(age)) age--;

			return age.ToString();
		}
	}
}
