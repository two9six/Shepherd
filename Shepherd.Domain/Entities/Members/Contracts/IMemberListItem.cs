﻿using Shepherd.Domain.Infrastructure.Contracts;
using SMM = Shepherd.Model.Models;

namespace Shepherd.Domain.Entities.Members.Contracts
{
	public interface IMemberListItem<T>
		: IListEntityItemBase<T, SMM.Member>
		where T : class
	{
		int MemberId { get; }

		string Name { get; set; }

		int AgeInSpirit { get; set; }

		string Status { get; set; }
	}
}