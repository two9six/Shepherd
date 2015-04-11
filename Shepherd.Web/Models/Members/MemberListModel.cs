using Shepherd.Domain.Contracts.Models.Members;
using System.ComponentModel.DataAnnotations;

namespace Shepherd.Web.Models.Members
{
	public sealed class MemberListModel
	{
		public IMemberList MemberList { get; private set; }

		public int CurrentPage { get; set; }

		public MemberListSearchCriteria SearchCriteria { get; set; }

		public MemberListModel() { }

		public MemberListModel(IMemberList memberList)
		{
			this.MemberList = memberList;
		}

		public void Generate()
		{
			this.MemberList.Fetch();
		}
	}
}