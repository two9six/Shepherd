using System;

namespace Shepherd.Model.Models
{
	public class Member
	{
		public int Id { get; set; }

		public int PersonId { get; set; }

		public string GeneratedId { get; set; }

		public int StatusId { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateUpdated { get; set; }

		public bool IsDeleted { get; set; }

		public virtual Person Person { get; set; }
	}
}