﻿using Shepherd.Domain.Models.Common;
using System;

namespace Shepherd.Domain.Models
{
	public class Member
	{
		public int Id { get; set; }

		public string ChurchId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MiddleName { get; set; }

		public DateTime BirthDate { get; set; }

		public string PlaceOfBirth { get; set; }

		public string Gender { get; set; }

		public string Citizenship { get; set; }

		public Address Address { get; set; }

		public DateTime DateBaptized { get; set; }

		public Baptizer Baptizer { get; set; }

		public string MaritalStatus { get; set; }

		public string SpouseName { get; set; }

		public ContactInformation ContactInformation { get; set; }

		public MemberStatus Status { get; set; }

		public MemberType Type { get; set; }

		public int ChurchDesignationId { get; set; }

		public int CreatedBy { get; set; }

		public DateTime DateCreated { get; set; }

		public int ModifiedBy { get; set; }

		public DateTime DateModified { get; set; }

		public Member()
		{
			this.Address = new Address();
			this.Baptizer = new Baptizer();
			this.ContactInformation = new ContactInformation();
		}

		public enum MemberStatus
		{
			Active = 1,
			InActive = 2,
			Suspended = 3,
			Excommunicated = 4
		}

		public enum MemberType
		{
			Member = 25,
			Officer = 26,
			Worker = 27
		}
	}
}