using Shepherd.BusinessLogic.Entities.Contracts;
using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Data.Repository.Contracts;
using System;
using Shepherd.Model.Models;

namespace Shepherd.BusinessLogic.Entities
{
	public sealed class MemberDetails : IMemberDetails
	{
		private readonly IMemberRepository memberRepository;
		private readonly IPersonRepository personRepository;
		private readonly IUnitOfWork unitOfWork;

		public int MemberId { get; private set; }

		public string GeneratedId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MiddleName { get; set; }

		public DateTime BirthDate { get; set; }

		public MemberDetails()
		{
			this.memberRepository = new Shepherd.Data.Repository.MemberRepository(new Shepherd.Data.Infrastructure.DatabaseFactory());
			this.personRepository = new Shepherd.Data.Repository.PersonRepository(new Shepherd.Data.Infrastructure.DatabaseFactory()); ;
			this.unitOfWork = new Shepherd.Data.Infrastructure.UnitOfWork(new Shepherd.Data.Infrastructure.DatabaseFactory());
		}

		public MemberDetails(IMemberRepository memberRepository, IPersonRepository personRepository, IUnitOfWork unitOfWork)
		{
			this.memberRepository = memberRepository;
			this.personRepository = personRepository;
			this.unitOfWork = unitOfWork;
		}

		public void Fetch(int memberId)
		{
			var member = memberRepository.GetById(memberId);

			if (member != null)
			{
				this.MemberId = member.Id;
				this.GeneratedId = member.GeneratedId;

				var person = personRepository.GetById(member.PersonId);

				if (person != null)
				{
					this.LastName = person.LastName;
					this.FirstName = person.FirstName;
					this.MiddleName = person.MiddleName;
					this.BirthDate = person.BirthDate;
				}
			}
		}


		public void CreateMember(Member member)
		{
			memberRepository.Add(member);
			this.SaveMember();
		}

		public void EditMember(Member memberToEdit)
		{
			memberRepository.Update(memberToEdit);
			this.SaveMember();
		}

		public void DeleteMember(int memberId)
		{
			var member = memberRepository.GetById(memberId);
			if (member != null)
			{
				member.IsDeleted = true;
				memberRepository.Update(member);

				this.SaveMember();
			}
		}

		public void SaveMember()
		{
			this.unitOfWork.Commit();
		}
	}
}