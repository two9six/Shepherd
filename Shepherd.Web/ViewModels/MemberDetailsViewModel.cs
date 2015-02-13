using System;
using System.ComponentModel.DataAnnotations;

namespace Shepherd.Web.ViewModels
{
	internal sealed class MemberDetailsViewModel
	{
		public int MemberId { get; private set; }

		public string GeneratedId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MiddleName { get; set; }

		[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
		public DateTime BirthDate { get; set; }
	}
}
