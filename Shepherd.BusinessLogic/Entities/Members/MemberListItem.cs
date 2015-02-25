using Shepherd.BusinessLogic.Entities.Members.Contracts;
using Shepherd.Core.Helpers;
using SMM = Shepherd.Model.Models;

namespace Shepherd.BusinessLogic.Entities.Members
{
	public sealed class MemberListItem : IMemberListItem<MemberListItem>
	{
		public int MemberId { get; private set; }

		public string Name { get; set; }

		public int AgeInSpirit { get; set; }

		public MemberListItem LoadChild(SMM.Member entity)
		{
			if (entity != null && entity.Person != null)
			{
				this.MemberId = entity.Id;
				this.Name = string.Format("{0} {1}", entity.Person.FirstName, entity.Person.LastName);
				this.AgeInSpirit = DateTimeHelpers.ComputeAge(entity.DateBabtized);
			}

			return this;
		}
	}
}