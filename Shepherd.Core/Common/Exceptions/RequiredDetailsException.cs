using System;

namespace Shepherd.Core.Common.Exceptions
{
	public class RequiredDetailsException : Exception
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