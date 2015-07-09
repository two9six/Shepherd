using Shepherd.WebApi.Contracts;

namespace Shepherd.WebApi.Models.Members
{
	public class Baptizer : IDomainConvertible<Domain.Models.Baptizer>
	{
		public int Id { get; set; }

		public Domain.Models.Baptizer ToDomainObject()
		{
			return new Domain.Models.Baptizer { Id = this.Id };
		}
	}
}