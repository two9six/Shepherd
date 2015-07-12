using Shepherd.Domain.Models;

namespace Shepherd.Domain.Services.Models.ServiceResponses.Members
{
	public sealed class AddMemberServiceResponse : ServiceResponse
	{
		public Member Member { get; set; }
	}
}