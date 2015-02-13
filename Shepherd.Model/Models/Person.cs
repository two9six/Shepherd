using System;

namespace Shepherd.Model.Models
{
	public class Person
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MiddleName { get; set; }

		public DateTime BirthDate { get; set; }

		public DateTime? DateCreated { get; set; }

		public DateTime? DateUpdated { get; set; }

		public bool IsDeleted { get; set; }
	}
}
