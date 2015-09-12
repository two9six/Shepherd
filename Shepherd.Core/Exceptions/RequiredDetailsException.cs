using System;

namespace Shepherd.Core.Exceptions
{
	public sealed class RequiredDetailsException : Exception
	{
		public RequiredDetailsException()
		{
		}

		public RequiredDetailsException(string message)
			: base(message)
		{
		}

		public RequiredDetailsException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}