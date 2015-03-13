using Shepherd.Domain.Constants;
using Shepherd.Domain.Entities.Members.Contracts;
using Shepherd.Core;
using Shepherd.Data.Contracts;
using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Data.Repository.Contracts;
using System;
using System.Collections.Generic;

namespace Shepherd.Domain.Entities.Members
{
	public sealed class MemberDetails : IMemberDetails
	{
		private readonly IUnitOfWork unitOfWork;

		public int MemberId { get; set; }

		public string GeneratedId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MiddleName { get; set; }

		public DateTime BirthDate { get; set; }

		public DateTime DateBabtized { get; set; }

		public MemberDetails(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public void Fetch(int memberId)
		{
			if (memberId <= 0)
			{
				throw new ArgumentException(Constants.ValidationMessages.ArgumentException.InvalidId, MemberDetails.MemberLabels.MemberId);
			}

			var member = unitOfWork.MemberRepository.GetByIdWithPerson(memberId);
			
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

		public void Add()
		{
			//memberRepository.Add();
		}

		public IEnumerable<ValidationResult> Update()
		{
			var validationResults = new List<ValidationResult>();

			var member = unitOfWork.MemberRepository.GetByIdWithPerson(this.MemberId);

			if (member == null)
			{
				validationResults.Add(new ValidationResult(MemberLabels.MemberId, ValidationMessages.MemberIdMemberNull));
			}
			else if (member.Person == null)
			{
				validationResults.Add(new ValidationResult(MemberLabels.MemberId, ValidationMessages.MemberIdPersonNull));
			}

			if (validationResults.Count == 0)
			{
				member.GeneratedId = this.GeneratedId;
				member.DateBabtized = this.DateBabtized;

				member.Person.FirstName = this.FirstName;
				member.Person.LastName = this.LastName;
				member.Person.MiddleName = this.MiddleName;
				member.Person.BirthDate = this.BirthDate;

				unitOfWork.MemberRepository.Edit(member);
				unitOfWork.Save();
			}

			return validationResults;
		}

		public void Delete(int memberId)
		{
			var member = unitOfWork.MemberRepository.GetById(memberId);
			if (member != null)
			{
				member.IsDeleted = true;
				unitOfWork.MemberRepository.Edit(member);
				unitOfWork.Save();
			}
		}

		public static class MemberLabels
		{
			public const string MemberId = "Member Id";
		}

		public static class ValidationMessages
		{
			public const string MemberIdMemberNull = "Member Id contain null Member entity";
			public const string MemberIdPersonNull = "Member Id contain null Person entity";
		}
	}
}