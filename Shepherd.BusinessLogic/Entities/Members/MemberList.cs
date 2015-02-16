﻿using Shepherd.BusinessLogic.Entities.Members.Contracts;
using Shepherd.BusinessLogic.Infrastructure;
using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Data.Repository.Contracts;

namespace Shepherd.BusinessLogic.Entities.Members
{
	public sealed class MemberList : ListEntityBase<MemberListItem>, IMemberList
	{
		private readonly IMemberRepository memberRepository;
		private readonly IPersonRepository personRepository;
		private readonly IUnitOfWork unitOfWork;

		public MemberList(IMemberRepository memberRepository, IPersonRepository personRepository, IUnitOfWork unitOfWork)
		{
			this.memberRepository = memberRepository;
			this.personRepository = personRepository;
			this.unitOfWork = unitOfWork;
		}

		public void Fetch()
		{
			var members = memberRepository.GetAllWithPerson();

			foreach (var member in members)
			{
				this.Items.Add(new MemberListItem().LoadChild(member));
			}
		}
	}
}