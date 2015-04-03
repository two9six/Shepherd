using System;

namespace Shepherd.Domain.Contracts.Infrastructure
{
	public interface ICurrentDate
	{
		DateTime GetNow(TimeZoneInfo timeZone);
		DateTime UtcNow { get; }
	}
}