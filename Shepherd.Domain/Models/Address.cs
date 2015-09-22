using Shepherd.Domain.Contracts.Models;
namespace Shepherd.Domain.Models
{
	public sealed class Address
		: IAddress
	{
		public string AddressLine1 { get; set; }

		public string AddressLine2 { get; set; }

		public string City { get; set; }

		public string StateProvince { get; set; }

		public string Country { get; set; }
	}
}