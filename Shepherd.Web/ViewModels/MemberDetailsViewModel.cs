using Shepherd.Domain.Entities.Members;
using Shepherd.Domain.Entities.Members.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shepherd.Web.ViewModels
{
	public class MemberDetailsViewModel
	{
		public int MemberId { get; set; }

		public string GeneratedId { get; set; }

		[Display(Name = "First name")]
		public string FirstName { get; set; }

		[Display(Name = "Last name")]
		public string LastName { get; set; }

		[Display(Name = "Middle name")]
		public string MiddleName { get; set; }

		[Display(Name = "Date babtized")]
		[DataType(DataType.DateTime)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime DateBabtized { get; set; }

		[Display(Name = "Birth date")]
		[DataType(DataType.DateTime)] 
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime BirthDate { get; set; }

		public void MapToBusinessEntity(IMemberDetails entity)
		{
			entity.MemberId = this.MemberId;
			entity.GeneratedId = this.GeneratedId;
			entity.FirstName = this.FirstName;
			entity.LastName = this.LastName;
			entity.MiddleName = this.MiddleName;
			entity.BirthDate = this.BirthDate;
			entity.DateBabtized = this.DateBabtized;
		}

		public void MapFromBusinessEntity(IMemberDetails entity)
		{
			this.MemberId = entity.MemberId;
			this.GeneratedId = entity.GeneratedId;
			this.FirstName = entity.FirstName;
			this.LastName = entity.LastName;
			this.MiddleName = entity.MiddleName;
			this.BirthDate = entity.BirthDate;
			this.DateBabtized = entity.DateBabtized;
		}
	}
}