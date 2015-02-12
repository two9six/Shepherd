using System;

namespace Shepherd.Data.Infrastructure.Contracts
{
	public interface IDatabaseFactory : IDisposable
	{
		ShepherdEntities Get(); 
	}
}
