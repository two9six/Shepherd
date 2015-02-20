using Shepherd.Model.Models;
using System;

namespace Shepherd.BusinessLogic.Entities.Members.Contracts
{
	public interface IMemberListItem<T> where T : class
	{
		int MemberId { get; }

		string Name { get; set; }

		int AgeInSpirit { get; set; }

		T LoadChild(Member member);
	}
}