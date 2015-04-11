using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Shepherd.Web.Extensions
{
	public static class DictionaryExtensions
	{
		public static IEnumerable<SelectListItem> ToSelectList(this IDictionary<string, string> @this)
		{
			return @this.ToList().Select(_ => new SelectListItem { Value = _.Key, Text = _.Value }).ToList();
		}
	}
}