using Shepherd.BusinessLogic.Entities.Members.Contracts;
using Shepherd.BusinessLogic.Infrastructure;
using Shepherd.Data.Repository.Contracts;

namespace Shepherd.BusinessLogic.Entities.Members
{
	public sealed class MemberList 
		: ListEntityBase<MemberListItem>, 
		IMemberList
	{
		private readonly IMemberRepository memberRepository;

		public MemberList(IMemberRepository memberRepository)
		{
			this.memberRepository = memberRepository;
		}

		public override void Fetch()
		{
			var members = memberRepository.GetAllWithPerson();

			foreach (var member in members)
			{
				this.Items.Add(new MemberListItem().LoadChild(member));
			}
		}
	}
}