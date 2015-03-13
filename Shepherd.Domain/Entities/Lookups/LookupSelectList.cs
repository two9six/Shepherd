using Shepherd.Domain.Entities.Lookups.Contracts;
using Shepherd.Domain.Infrastructure;
using Shepherd.Core.Common;
using Shepherd.Core.Extensions;
using Shepherd.Data.Contracts;

namespace Shepherd.Domain.Entities.Lookups
{
	public sealed class LookupSelectList
		: ListEntityBase<LookupSelectListItem>,
		ILookupSelectList
	{
		private readonly IUnitOfWork unitOfWork;

		public LookupSelectList(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public void Fetch(Identifiers.LookupTypes lookupType)
		{
			var lookups = unitOfWork.LookupRepository.GetByLookupTypeId(lookupType.ToInt());

			foreach (var lookup in lookups)
			{
				this.Items.Add(new LookupSelectListItem().LoadChild(lookup));
			}
		}
	}
}