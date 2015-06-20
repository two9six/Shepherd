using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Domain.Contracts.Infrastructure;
using Shepherd.Domain.Contracts.Models.Members;
using Shepherd.Domain.Infrastructure;
using System.Linq;

namespace Shepherd.Domain.Models.Members
{
	public sealed class MemberList
		: ModelListBase<MemberListItem>,
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
				this.Items.Add(new MemberListItem(unitOfWork).FetchChild(member));
			}
		}

		public void Fetch(MemberListSearchCriteria criteria)
		{
			var members = unitOfWork.MemberRepository
				.FindBy(_ =>
					_.Person.LastName.Contains(criteria.LastName) &&
					_.Person.FirstName.Contains(criteria.FirstName) &&
					_.DateBaptized > criteria.DateBabtizedFrom && _.DateBaptized <= criteria.DateBabtizedTo)
				.OrderBy(_ => _.Person.LastName);

			foreach (var member in members)
			{
				this.Items.Add(new MemberListItem(unitOfWork).FetchChild(member));
			}
		}
	}
}