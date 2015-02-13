
namespace Shepherd.BusinessLogic.Infrastructure.Contracts
{
	public interface IReadOnlyEntity<T> where T : class
	{
		void Fetch(int id);
	}
}