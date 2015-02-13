using System;
using System.ComponentModel.DataAnnotations;

namespace Shepherd.Web.ViewModels
{
	public class MemberDetailsViewModel
	{
		public int MemberId { get; private set; }

		public string GeneratedId { get; set; }

		[Display(Name = "First name")]
		public string FirstName { get; set; }

		[Display(Name = "Last name")]
		public string LastName { get; set; }

		[Display(Name = "Middle name")]
		public string MiddleName { get; set; }

		[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
		public DateTime BirthDate { get; set; }
	}
}
