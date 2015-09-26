using Shepherd.Core.Enums;
using System;
using System.Collections.Generic;

namespace Shepherd.Domain.Contracts.Models
{
	public interface IGathering
	{
		int Id { get; set; }
		GatheringTypes GatheringType { get; set; }
		IGatheringSchedule GatheringSchedule { get; set; }
		DateTime ActualStart { get; set; }
		DateTime ActualEnd { get; set; }
		List<IWorker> WorkersOnDuty { get; set; }
		List<IOfficer> OfficersOnDuty { get; set; }

		void Load();
	}
}