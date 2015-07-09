namespace Shepherd.WebApi.Contracts
{
	public interface IDomainConvertible<T>
		where T : class
	{
		T ToDomainObject();
	}
}
