using Newtonsoft.Json;
using Shepherd.Core.Exceptions;
using Shepherd.WebApi.Infrastructure.Common;
using Shepherd.WebApi.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shepherd.WebApi.Infrastructure.Extensions
{
	public static class ApiControllerExtensions
	{
		public static void ValidateInput<T>(this ApiController controller, IValidatable request) where T : APIResponse, new()
		{
			if (request == null)
				throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "Unable to determine request parameters." });

			var errors = request.GetValidationErrors();
			if (errors.Count() > 0)
				throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
				{
					ReasonPhrase = "Validation errors occurred.",
					Content = new StringContent(
						JsonConvert.SerializeObject(new T { Message = "Validation errors occurred.", Errors = errors }),
						System.Text.Encoding.Unicode, "application/json")
				});
		}

		public static Exception HandleGeneralError<T>(this ApiController controller, Exception ex) where T : APIResponse, new()
		{
			if (ex is HttpResponseException)
			{
				return ex;
			}
			if (ex is ModelNotFoundException)
			{
				return new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound) { ReasonPhrase = ex.Message });
			}
			else if (ex is BusinessLogicException)
			{
				return new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Conflict) { ReasonPhrase = ex.Message });
			}
			else if (ex is RequiredDetailsException)
			{
				return new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "Validation errors occurred.", Content = new StringContent(JsonConvert.SerializeObject(new T { Message = "Validation errors occurred.", Errors = new List<string> { ex.Message } }), System.Text.Encoding.Unicode, "application/json") });
			}
			else if (ex is AuthorizationFailedException)
			{
				return new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = ex.Message });
			}

			return new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError) { ReasonPhrase = "An unexpected error has occurred." });
		}
	}
}