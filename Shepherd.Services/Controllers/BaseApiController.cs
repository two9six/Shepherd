using Shepherd.Core.Exceptions;
using System;
using System.Data.Entity.Validation;
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
			// TODO: Catch all known exceptions and return HTTP 400
			// Exceptions found in Shepherd.Core.Exceptions should all return HTTP 400
			// Other exceptions will return 500
			// Refer to this: https://msdn.microsoft.com/en-us/library/system.net.httpstatuscode(v=vs.118).aspx 
			try
			{
				var returnObject = callBack();

				if (returnObject != null)
				{
					return Ok(returnObject);
				}
				else
				{
					return NotFound();
				}
			}
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
			catch (ModelNotFoundException ex)
			{
				LogException(ex);
				return BadRequest(ex.Message);
			}
			catch (Exception ex)
			{
				LogException(ex);
				return InternalServerError();
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