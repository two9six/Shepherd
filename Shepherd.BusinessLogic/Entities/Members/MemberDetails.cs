using Shepherd.BusinessLogic.Constants;
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

		public int MemberId { get; set; }

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
			if (memberId <= 0)
			{
				throw new ArgumentException(ValidationMessages.ArgumentException.InvalidId, MemberDetails.MemberLabels.MemberId);
			}

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

		public void Create(Member member)
		{
			memberRepository.Add(member);
			this.Save();
		}

		public void Update()
		{
			var member = memberRepository.GetByIdWithPerson(this.MemberId);

			if (member == null || member.Person==null)
			{
				throw new NullReferenceException(ValidationMessages.NullReferenceException.UpdateFailed);
			}
			else
			{
				member.GeneratedId = this.GeneratedId;
				member.DateBabtized = this.DateBabtized;

				member.Person.FirstName = this.FirstName;
				member.Person.LastName = this.LastName;
				member.Person.MiddleName = this.MiddleName;
				member.Person.BirthDate = this.BirthDate;

				memberRepository.Update(member);
				this.Save();
			}
		}

		public void Delete(int memberId)
		{
			var member = memberRepository.GetById(memberId);
			if (member != null)
			{
				member.IsDeleted = true;
				memberRepository.Update(member);

				this.Save();
			}
		}

		public void Save()
		{
			this.unitOfWork.Commit();
		}

		public static class MemberLabels
		{
			public const string MemberId = "Member Id";
		}
	}
}