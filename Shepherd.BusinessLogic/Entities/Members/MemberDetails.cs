using Shepherd.BusinessLogic.Entities.Members.Contracts;
using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Data.Repository.Contracts;
using Shepherd.Model.Models;
using System;

namespace Shepherd.BusinessLogic.Entities.Members
{
	public sealed class MemberDetails : IMemberDetails
	{
		private readonly IMemberRepository memberRepository;
		private readonly IUnitOfWork unitOfWork;

		public int MemberId { get; private set; }

		public string GeneratedId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MiddleName { get; set; }

		public DateTime BirthDate { get; set; }

		public DateTime DateBabtized { get; set; }

		public MemberDetails(IMemberRepository memberRepository, IUnitOfWork unitOfWork)
		{
			this.memberRepository = memberRepository;
			this.unitOfWork = unitOfWork;
		}

		public void Fetch(int memberId)
		{
			var member = memberRepository.GetByIdWithPerson(memberId);
			
			if (member != null)
			{
				this.MemberId = member.Id;
				this.GeneratedId = member.GeneratedId;
				this.DateBabtized = member.DateBabtized;

				if (member.Person != null)
				{
					this.LastName = member.Person.LastName;
					this.FirstName = member.Person.FirstName;
					this.MiddleName = member.Person.MiddleName;
					this.BirthDate = member.Person.BirthDate;
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