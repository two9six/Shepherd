using Shepherd.Model.Models;

namespace Shepherd.Data.Repository.Contracts
{
	public interface IMemberRepository
	{
		Member GetByMemberId(string memberId);
	}
}