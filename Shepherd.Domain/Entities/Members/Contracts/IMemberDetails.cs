﻿using Shepherd.Core;
using System;
using System.Collections.Generic;

namespace Shepherd.Domain.Entities.Members.Contracts
{
	public interface IMemberDetails
	{
		int MemberId { get; set; }

		string GeneratedId { get; set; }

		string FirstName { get; set; }

		string LastName { get; set; }

		string MiddleName { get; set; }

		DateTime BirthDate { get; set; }

		DateTime DateBabtized { get; set; }

		void Fetch(int memberId);

		void Add();

		ProcessResult Update();

		void Delete(int memberId);
	}
}