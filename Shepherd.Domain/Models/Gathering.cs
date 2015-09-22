using Shepherd.Core.Enums;
using Shepherd.Domain.Contracts.Models;
using System;
using System.Collections.Generic;

namespace Shepherd.Domain.Models
{
	public sealed class Gathering
		: IGathering
	{
		public int Id { get; set; }

		public GatheringTypes GatheringType { get; set; }

		public DateTime ActualStart { get; set; }

		public DateTime ActualEnd { get; set; }

		public IGatheringSchedule GatheringSchedule { get; set; }

		public List<IWorker> WorkersOnDuty { get; set; }

		public List<IOfficer> OfficersOnDuty { get; set; }
	}
}