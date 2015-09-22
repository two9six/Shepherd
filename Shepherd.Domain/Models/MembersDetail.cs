using Shepherd.Domain.Contracts.Models;

namespace Shepherd.Domain.Models
{
	public class MembersDetail : IMembersDetail
	{
		public int Id { get; set; }
		public Member Member { get; set; }

		public void Load()
		{
			this.Member.Id = this.Id;
			this.Member.Load();
		}
	}
}