namespace Shepherd.Domain.Contracts.Models
{
	public interface IAddress
	{
		string AddressLine1 { get; set; }
		string AddressLine2 { get; set; }
		string City { get; set; }
		string StateProvince { get; set; }
		string Country { get; set; }
	}
}
