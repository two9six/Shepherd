using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Domain.Contracts.Services.Lookup;
using Shepherd.Domain.Common.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Shepherd.Domain.Services.Lookup
{
	public class LookupSelectListService : ILookupSelectListService
	{
		private readonly IUnitOfWork unitOfWork;

		public LookupSelectListService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public Dictionary<string, string> GetSelectList(LookupTypes lookupType, SelectListOptions.DefaultValue defaultValueOption = SelectListOptions.DefaultValue.Default)
		{
			var dictionary = new Dictionary<string, string>();
			var lookups = unitOfWork.LookupRepository.GetByLookupTypeId((int)lookupType);

			foreach (var lookup in lookups.OrderByDescending(_ => _.IsDefault).ThenBy(_ => _.Name))
			{
				dictionary.Add(lookup.Id.ToString(), lookup.Name);
			}

			return dictionary;
		}
	}
}