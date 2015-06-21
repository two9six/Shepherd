using System.Collections.Generic;

namespace Shepherd.WebApi.Infrastructure.Contracts
{
	public interface IValidatable
	{
		IList<string> GetValidationErrors();
	}
}