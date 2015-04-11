using System.ComponentModel.DataAnnotations;

namespace Shepherd.Web.Models.Members
{
	public sealed class MemberListSearchCriteria
	{
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Display(Name = "Date Babtized From")]
		public bool DateBabtizedFrom { get; set; }

		[Display(Name = "Date Babtized To")]
		public bool DateBabtizedTo { get; set; }
	}
}