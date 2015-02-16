using Shepherd.BusinessLogic.Entities.Members.Contracts;
using Shepherd.Model.Models;
using System;

namespace Shepherd.BusinessLogic.Entities.Members
{
	public sealed class MemberListItem : IMemberListItem<MemberListItem>
	{
		public int MemberId { get; private set; }

		public string Name { get; set; }

		public DateTime DateBabtized { get; set; }

		public MemberListItem LoadChild(Member member)
		{
			if (member != null && member.Person != null)
			{
				this.MemberId = member.Id;
				this.Name = string.Format("{0} {1}", member.Person.FirstName, member.Person.LastName);
				this.DateBabtized = member.DateBabtized;
			}

			return this;
		}
	}
}