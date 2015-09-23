using Shepherd.Domain.Contracts.Models;

namespace Shepherd.Domain.Models
{
	public sealed class MembersDetail : IMembersDetail
	{
		public int Id { get; set; }
		public Member Member { get; set; }

		public MembersDetail()
		{
			this.Member = new Member();
		}

		public void Load()
		{
			this.Member.Id = this.Id;
			this.Member.Load();
		}
	}
}