
namespace Shepherd.Domain.Contracts.Models
{
	public interface ICommitteeMember
	{
		int Id { get; set; }
		IMember Member { get; set; }
		bool IsCommitteeHead { get; set; }
	}
}
