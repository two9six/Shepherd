using System;

namespace Shepherd.Web.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public sealed class DependencyAttribute : Attribute	
	{	
	}
}