using Shepherd.Domain.Models;
using System;
using System.Collections.Generic;

namespace Shepherd.Domain.Contracts.Models.Reporting
{
	public interface IMonthlyCelebrants
	{
		int Month { get; set; }

		List<IMonthlyCelebrator> Celebrators { get; set; }

		void Load();
	}

	public interface IMonthlyCelebrator
	{
		int Id { get; set; }
		string Name { get; set; }
		DateTime DateBaptized { get; set; }
		int Age { get; set; }
		string Gender { get; set; }
		string Landline { get; set; }
		string MobileNumber { get; set; }
		string Address { get; set; }
	}
}
