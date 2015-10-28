using Shepherd.Domain.Contracts.Models;

namespace Shepherd.Domain.Models
{
	public sealed class CommitteeMember
		: ICommitteeMember
	{
		public int Id { get; set; }
		public IMember Member { get; set; }
		public bool IsCommitteeHead { get; set; }
	}
}