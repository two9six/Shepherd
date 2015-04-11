using Shepherd.Core.Common;
using Shepherd.Core.Extensions;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Domain.Contracts.Models.Lookups;
using Shepherd.Domain.Infrastructure;
using Shepherd.Domain.Contracts.Infrastructure;

namespace Shepherd.Domain.Models.Lookups
{
	public sealed class LookupSelectList
		: ModelListBase<LookupSelectListItem>,
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
				this.Items.Add(new LookupSelectListItem().FetchChild(lookup));
			}
		}


		public void Fetch(IModelListSearchCriteria criteria)
		{
			throw new System.NotImplementedException();
		}
	}
}