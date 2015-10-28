using System.Collections.Generic;

namespace Shepherd.Domain.Contracts.Models
{
	public interface ICommittee
	{
		int Id { get; set; }
		string Name { get; set; }
		string Description { get; set; }
		bool IsActive { get; set; }
		bool IsDeleted { get; set; }
		List<ICommitteeMember> Members { get; set; }

		void Load();
		void Insert();
		void Update();
	}
}