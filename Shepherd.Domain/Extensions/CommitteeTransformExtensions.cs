using Shepherd.Domain.Contracts.Models;

namespace Shepherd.Domain.Extensions
{
	public static class CommitteeTransformExtensions
	{
		public static void LoadFromEntity(this ICommittee committee, Entities.Committee committeeEntity)
		{
			if (committeeEntity != null)
			{
				committee.Id = committeeEntity.Id;
				committee.Name = committeeEntity.Name;
				committee.Description = committeeEntity.Description;
				committee.IsActive = committeeEntity.IsActive;
				committee.IsDeleted = committeeEntity.IsDeleted;
			}
		}

		public static Entities.Committee ToEntity(this ICommittee committee)
		{
			var committeeEntity = new Entities.Committee();

			if (committee != null)
			{
				committeeEntity = new Entities.Committee()
				{
					Id = committee.Id,
					Name = committee.Name,
					Description = committee.Description,
					IsActive = committee.IsActive,
					IsDeleted = committee.IsDeleted
				};
			}

			return committeeEntity;
		}
	}
}