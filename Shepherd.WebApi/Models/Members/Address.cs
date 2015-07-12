using Shepherd.WebApi.Contracts;

namespace Shepherd.WebApi.Models.Members
{
	public sealed class Address 
		: IDomainConvertible<Domain.Models.Common.Address>
	{
		public string AddressLine1 { get; set; }

		public string AddressLine2 { get; set; }

		public string City { get; set; }

		public string StateProvince { get; set; }

		public string Country { get; set; }

		public Domain.Models.Common.Address ToDomainObject()
		{
			return new Domain.Models.Common.Address
			{
				AddressLine1 = this.AddressLine1,
				AddressLine2 = this.AddressLine2,
				City = this.City,
				StateProvince = this.StateProvince,
				Country = this.Country
			};
		}

		public void LoadFromDomainObject(Domain.Models.Common.Address domainObject)
		{
			if (domainObject != null)
			{
				this.AddressLine1 = domainObject.AddressLine1;
				this.AddressLine2 = domainObject.AddressLine2;
				this.City = domainObject.City;
				this.StateProvince = domainObject.StateProvince;
				this.Country = domainObject.Country;
			}
		}
	}
}