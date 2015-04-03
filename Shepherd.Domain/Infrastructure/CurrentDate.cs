using Shepherd.Domain.Contracts.Infrastructure;
using System;

namespace Shepherd.Domain.Infrastructure
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
