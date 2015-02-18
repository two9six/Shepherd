using Shepherd.BusinessLogic.Contracts;
using System;

namespace Shepherd.BusinessLogic
{
	public sealed class CurrentDate : ICurrentDate
	{
		public DateTime GetNow(TimeZoneInfo timeZone)
		{
			return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
		}

		public DateTime UtcNow
		{
			get { return DateTime.UtcNow; }
		}
	}
}
