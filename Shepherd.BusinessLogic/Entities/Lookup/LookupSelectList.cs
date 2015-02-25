using Shepherd.BusinessLogic.Entities.Lookup.Contracts;
using Shepherd.BusinessLogic.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shepherd.Core.Common;
using Shepherd.Data.Repository.Contracts;
using Shepherd.Core.Extensions;

namespace Shepherd.BusinessLogic.Entities.Lookup
{
	public sealed class LookupSelectList
		: ListEntityBase<LookupSelectListItem>,
		ILookupSelectList
	{
		private readonly ILookupRepository lookupRepository;

		public LookupSelectList(ILookupRepository lookupRepository)
		{
			this.lookupRepository = lookupRepository;
		}

		public void Fetch(Identifiers.LookupTypes lookupType)
		{
			var lookups = lookupRepository.GetByLookupTypeId(lookupType.ToInt());

			foreach (var lookup in lookups)
			{
				this.Items.Add(new LookupSelectListItem().LoadChild(lookup));
			}
		}
	}
}