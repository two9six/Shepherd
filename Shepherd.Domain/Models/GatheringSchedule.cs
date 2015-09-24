using Shepherd.Core.Enums;
using Shepherd.Domain.Contracts.Models;
using System;
using System.Collections.Generic;

namespace Shepherd.Domain.Models
{
	public sealed class GatheringSchedule
		: IGatheringSchedule
	{
		public int Id { get; set; }

		public GatheringTypes GatheringType { get; set; }

		public TimeSpan StartTime { get; set; }

		public TimeSpan EndTime { get; set; }

		public List<IWorker> AssignedWorkers { get; set; }

		public List<IOfficer> AssignedOfficers { get; set; }

		public string Notes { get; set; }

		public void Load()
		{
			throw new NotImplementedException();
		}
	}
}