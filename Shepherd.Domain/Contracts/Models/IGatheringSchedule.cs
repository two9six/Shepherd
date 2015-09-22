using Shepherd.Core.Enums;
using System;
using System.Collections.Generic;

namespace Shepherd.Domain.Contracts.Models
{
	public interface IGatheringSchedule
	{
		int Id { get; set; }
		GatheringTypes GatheringType { get; set; }
		TimeSpan StartTime { get; set; }
		TimeSpan EndTime { get; set; }
		List<IWorker> AssignedWorkers { get; set; }
		List<IOfficer> AssignedOfficers { get; set; }
		string Notes { get; set; }
	}
}