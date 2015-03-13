using System;

namespace Shepherd.Domain.Contracts
{
	public interface ICurrentDate
	{
		DateTime GetNow(TimeZoneInfo timeZone);
		DateTime UtcNow { get; }
	}
}