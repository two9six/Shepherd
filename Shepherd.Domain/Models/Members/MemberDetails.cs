using Shepherd.Core.Models;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Domain.Constants;
using Shepherd.Domain.Contracts.Models.Members;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Domain.Models.Members
{
	public sealed class MemberDetails : IMemberDetails
	{
		private readonly IUnitOfWork unitOfWork;

		public int MemberId { get; set; }

		public string ChurchId { get; set; }

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
				throw new ArgumentException(Constants.GenericValidationMessages.ArgumentException.InvalidId, MemberDetails.MemberLabels.MemberId);
			}

			var member = unitOfWork.MemberRepository.GetByIdWithPerson(memberId);

			if (member != null)
			{
				this.MemberId = member.Id;
				this.ChurchId = member.ChurchId;
				this.DateBabtized = member.DateBaptized;

				if (member.Person != null)
				{
					this.LastName = member.Person.LastName;
					this.FirstName = member.Person.FirstName;
					this.MiddleName = member.Person.MiddleName;
					this.BirthDate = member.Person.BirthDate;
				}
			}
		}

		public ServiceResult Add()
		{
			return new ServiceResult();
		}

		public ServiceResult Update()
		{
			var processResult = new ServiceResult();
			processResult.ValidationResults = this.ValidateUpdate();

			if (processResult.ValidationResults.Count() > 0)
			{
				return processResult;
			}

			var member = unitOfWork.MemberRepository.GetByIdWithPerson(this.MemberId);

			if (member == null)
			{
				processResult.ValidationResults.Add(new ValidationResult(MemberLabels.MemberId, ValidationMessages.MemberIdMemberNull));
			}
			else if (member.Person == null)
			{
				processResult.ValidationResults.Add(new ValidationResult(MemberLabels.MemberId, ValidationMessages.MemberIdPersonNull));
			}
			else
			{
				member.ChurchId = this.ChurchId;
				member.DateBaptized = this.DateBabtized;

				member.Person.FirstName = this.FirstName;
				member.Person.LastName = this.LastName;
				member.Person.MiddleName = this.MiddleName;
				member.Person.BirthDate = this.BirthDate;

				unitOfWork.MemberRepository.Edit(member);
				unitOfWork.Save();
			}

			return processResult;
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

		private List<ValidationResult> ValidateUpdate()
		{
			var validationResults = new List<ValidationResult>();

			// TODO: Implement auto validation with reflection
			if (string.IsNullOrEmpty(this.ChurchId))
			{
				validationResults.Add(
					new ValidationResult(MemberDetails.MemberLabels.GeneratedId,
						GenericValidationMessages.Common.CannotBeNullOrEmpty));
			}

			if (string.IsNullOrEmpty(this.FirstName))
			{
				validationResults.Add(
					new ValidationResult(MemberDetails.MemberLabels.FirstName,
						GenericValidationMessages.Common.CannotBeNullOrEmpty));
			}

			if (string.IsNullOrEmpty(this.LastName))
			{
				validationResults.Add(
					new ValidationResult(MemberDetails.MemberLabels.LastName,
						GenericValidationMessages.Common.CannotBeNullOrEmpty));
			}



			return validationResults;
		}

		public static class MemberLabels
		{
			public const string MemberId = "Member Id";
			public const string GeneratedId = "Generated Id";
			public const string FirstName = "First Name";
			public const string LastName = "Last Name";
		}

		public static class ValidationMessages
		{
			public const string MemberIdMemberNull = "Member Id contain null Member entity";
			public const string MemberIdPersonNull = "Member Id contain null Person entity";
		}
	}
}