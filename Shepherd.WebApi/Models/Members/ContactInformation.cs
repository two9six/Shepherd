using Shepherd.WebApi.Contracts;

namespace Shepherd.WebApi.Models.Members
{
	public sealed class ContactInformation 
		: IDomainConvertible<Domain.Models.Common.ContactInformation>
	{
		public string LandLine { get; set; }

		public string MobileNumber { get; set; }

		public string Email { get; set; }

		public Domain.Models.Common.ContactInformation ToDomainObject()
		{
			return new Domain.Models.Common.ContactInformation
			{
				LandLine = this.LandLine,
				MobileNumber = this.MobileNumber,
				Email = this.Email
			};
		}

		public void LoadFromDomainObject(Domain.Models.Common.ContactInformation domainObject)
		{
			if (domainObject != null)
			{
				this.LandLine = domainObject.LandLine;
				this.MobileNumber = domainObject.MobileNumber;
				this.Email = domainObject.Email;
			}
		}
	}
}