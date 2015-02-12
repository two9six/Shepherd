using System.Linq;

namespace Shepherd.Data.Infrastructure
{
	public static class PagingExtensions
	{
		public static IQueryable<T> GetPage<T>(this IQueryable<T> queryable, Page page)
		{
			return queryable.Skip(page.Skip).Take(page.PageSize);
		}
	}
}
