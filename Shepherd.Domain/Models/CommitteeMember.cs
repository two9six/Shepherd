using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Infrastructure;
using Shepherd.Domain.Contracts.Models;
using System;

namespace Shepherd.Domain.Models
{
	public sealed class CommitteeMember
		: ICommitteeMember
	{
		public int Id { get; set; }
		public int CommitteeId { get; set; }
		public int MemberId { get; set; }
		public IMember Member { get; set; }
		public bool IsCommitteeHead { get; set; }

		private readonly IUnitOfWork unitOfWork;

		public CommitteeMember()
			: this(UnitOfWork.Instance)
		{
		}

		public CommitteeMember(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public void Insert()
		{
			var entityCommitteeMember = new Entities.CommitteeMember
			{
				CommitteeId = this.CommitteeId,
				MemberId = this.MemberId,
				IsCommitteeHead = this.IsCommitteeHead,
				CreatedBy = 1,
				DateCreated = DateTime.Now
			};
			var createdCommitteeMember = unitOfWork.CommitteeMemberRepository.Add(entityCommitteeMember);

			unitOfWork.Save();

			this.Id = createdCommitteeMember.Id;
		}

		public void Delete()
		{
			var committeeMember = unitOfWork.CommitteeMemberRepository.GetById(this.Id);

			if (committeeMember != null)
			{
				unitOfWork.CommitteeMemberRepository.Delete(committeeMember);
				unitOfWork.Save();
			}
		}
	}
}