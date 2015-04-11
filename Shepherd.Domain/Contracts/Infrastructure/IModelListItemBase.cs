namespace Shepherd.Domain.Contracts.Infrastructure
{
	public interface IModelListItemBase<TItem, TItemModel>
		where TItem : class
		where TItemModel : class
	{
		TItem FetchChild(TItemModel entity);
	}
}