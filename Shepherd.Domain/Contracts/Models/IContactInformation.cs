namespace Shepherd.Domain.Contracts.Models
{
	public interface IContactInformation
	{
		string LandLine { get; set; }
		string MobileNumber { get; set; }
		string Email { get; set; }
	}
}