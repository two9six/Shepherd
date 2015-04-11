using System;

namespace Shepherd.Web.Extensions
{
	public static class TypeExtensions
	{
		private const string ControllerName = "Controller";

		public static string GetControllerName(this Type @this)
		{
			if (@this == null)
			{
				throw new ArgumentNullException("this");
			}

			return @this.Name.Replace(TypeExtensions.ControllerName, "");
		}
	}
}