
namespace Shepherd.BusinessLogic.Infrastructure.Contracts
{
	public interface IReadOnlyEntity<T> where T : class
	{
		T Fetch(int id);
	}
}