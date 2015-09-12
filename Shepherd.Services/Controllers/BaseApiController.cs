using System;
using System.Diagnostics;
using System.Text;
using System.Web.Http;

namespace Shepherd.Services.Controllers
{
	public abstract class BaseApiController : ApiController
	{
		protected void LogInfo(string message)
		{
			// TODO: Put logging logic here
		}

		/// <summary>
		/// Shared logic for exception handling, logging errors, and returning action results for all controller
		/// actions. This leverages delegates to encapsulate what would otherwise be repeating biolerplate code. 
		/// </summary>
		protected IHttpActionResult GetActionResult<T>(ActionResultDelegate<T> callBack)
		{
			try
			{
				var returnObject = callBack();
				return Ok(returnObject);
			}
			catch (Exception ex)
			{
				LogException(ex);
				/*
				TODO:	Use proper HTTP code
						If the exception caused by user and can be corrected by user, use the correct HTTP 4XX result, 
						If the exception is caused by system and the user can't do anything about it, use HTTP 500
				*/
				return NotFound();
			}
		}

		private void LogException(Exception ex)
		{
			StringBuilder message = new StringBuilder("Error occurred calling: ");
			message.Append(new StackFrame(2, true).GetMethod().Name);
			message.Append(".  See nested exception for details.");
			// TODO: Log the exception
		}

		public delegate T ActionResultDelegate<T>();
	}
}