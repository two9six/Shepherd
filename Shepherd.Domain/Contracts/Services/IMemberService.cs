using Shepherd.Core.Models;
using Shepherd.Domain.Models;

namespace Shepherd.Domain.Contracts.Services
{
	public interface IMemberService
	{
		ServiceResponse AddMember(Member member);
	}
}