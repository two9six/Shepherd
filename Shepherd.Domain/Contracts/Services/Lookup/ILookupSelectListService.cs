using Shepherd.Domain.Enums;
using System.Collections.Generic;

namespace Shepherd.Domain.Contracts.Services.Lookup
{
	public interface ILookupSelectListService
	{
		Dictionary<string, string> GetSelectList(LookupTypes lookupType, SelectListOptions.DefaultValue defaultValueOption = SelectListOptions.DefaultValue.Default);
	}
}