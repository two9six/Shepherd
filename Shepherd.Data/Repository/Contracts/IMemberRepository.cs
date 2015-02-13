using Shepherd.Data.Infrastructure.Contracts;
using Shepherd.Model.Models;

namespace Shepherd.Data.Repository.Contracts
{
	public interface IMemberRepository : IRepository<Member>
	{
		Member GetByGeneratedId(string generatedId);
	}
}