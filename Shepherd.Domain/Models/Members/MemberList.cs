using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Domain.Contracts.Models.Members;
using Shepherd.Domain.Infrastructure;

namespace Shepherd.Domain.Models.Members
{
	public sealed class MemberList
		: ListEntityBase<MemberListItem>,
		IMemberList
	{
		private readonly IUnitOfWork unitOfWork;

		public MemberList(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public override void Fetch()
		{
			var members = unitOfWork.MemberRepository.GetAllWithPerson();

			foreach (var member in members)
			{
				this.Items.Add(new MemberListItem(unitOfWork).LoadChild(member));
			}
		}
	}
}