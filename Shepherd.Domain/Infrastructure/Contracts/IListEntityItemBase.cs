namespace Shepherd.Domain.Infrastructure.Contracts
{
	public interface IListEntityItemBase<TItem, TItemModel>
		where TItem : class
		where TItemModel : class
	{
		TItem LoadChild(TItemModel entity);
	}
}