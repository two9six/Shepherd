using Shepherd.Domain.Contracts;
using System;

namespace Shepherd.Domain
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
