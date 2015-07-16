using Shepherd.Domain.Models;
using System.Collections.Generic;

namespace Shepherd.Domain.Contracts.Models
{
	public interface IMembersIndex
	{
		string ChurchId { get; set; }
		string Name { get; set; }
		List<Member> Members { get; set; }

		void Load();
	}
}
