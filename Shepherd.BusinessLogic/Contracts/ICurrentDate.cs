using System;

namespace Shepherd.BusinessLogic.Contracts
{
	public interface ICurrentDate
	{
		DateTime GetNow(TimeZoneInfo timeZone);
		DateTime UtcNow { get; }
	}
}