using Shepherd.Core.Models;
using Shepherd.Domain.Models;

namespace Shepherd.Domain.Contracts.Services
{
	public interface IMemberService
	{
		ServiceResult AddMember(Member member);
	}
}