using Shepherd.BusinessLogic.Entities.Lookup.Contracts;
using Shepherd.BusinessLogic.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shepherd.BusinessLogic.Entities.Lookup
{
	public sealed class LookupType : ILookupType<Lookup>
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public bool IsDeleted { get; set; }

		public List<Lookup> Lookups { get; set; }
	}
}