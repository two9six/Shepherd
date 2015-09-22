using Shepherd.Domain.Models;

namespace Shepherd.Domain.Contracts.Models
{
    public interface IMembersDetail
    {
		int Id { get; set; }
		Member Member { get; set; }
		void Load();
    }
}