using Shepherd.Model.Models;
using System;

namespace Shepherd.BusinessLogic.Entities.Members.Contracts
{
	public interface IMemberListItem
	{
		int MemberId { get; }

		string Name { get; set; }

		DateTime DateBabtized { get; set; }

		void Load(Member member);
	}
}