﻿using Shepherd.WebApi.Contracts;

namespace Shepherd.WebApi.Models.Members
{
	public sealed class Baptizer 
		: IDomainConvertible<Domain.Models.Baptizer>
	{
		public int Id { get; set; }

		public Domain.Models.Baptizer ToDomainObject()
		{
			return new Domain.Models.Baptizer { Id = this.Id };
		}

		public void LoadFromDomainObject(Domain.Models.Baptizer domainObject)
		{
			if (domainObject != null)
			{
				this.Id = domainObject.Id;
			}
		}
	}
}