using Shepherd.BusinessLogic.Entities.Members.Contracts;
using Shepherd.Core.Helpers;
using Shepherd.Model.Models;

namespace Shepherd.BusinessLogic.Entities.Members
{
	public sealed class MemberListItem : IMemberListItem<MemberListItem>
	{
		public int MemberId { get; private set; }

		public string Name { get; set; }

		public int AgeInSpirit { get; set; }

		public MemberListItem LoadChild(Member member)
		{
			if (member != null && member.Person != null)
			{
				this.MemberId = member.Id;
				this.Name = string.Format("{0} {1}", member.Person.FirstName, member.Person.LastName);
				this.AgeInSpirit = DateTimeHelpers.ComputeAge(member.DateBabtized);
			}

			return this;
		}
	}
}