﻿using Shepherd.Domain.Entities.Members.Contracts;
using Shepherd.Domain.Infrastructure;
using Shepherd.Data.Contracts;
using Shepherd.Data.Repository.Contracts;

namespace Shepherd.Domain.Entities.Members
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