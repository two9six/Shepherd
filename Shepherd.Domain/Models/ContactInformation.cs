using Shepherd.Domain.Contracts.Models;

namespace Shepherd.Domain.Models
{
	public sealed class ContactInformation
	{
		public string LandLine { get; set; }

		public string MobileNumber { get; set; }

		public string Email { get; set; }
	}
}