using Shepherd.Domain.Contracts.Infrastructure;
using System;

namespace Shepherd.Domain.Models.Members
{
	public sealed class MemberListSearchCriteria : IModelListSearchCriteria
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public int MemberTypeId { get; set; }

		public DateTime DateBabtizedFrom { get; set; }

		public DateTime DateBabtizedTo { get; set; }

	}
}