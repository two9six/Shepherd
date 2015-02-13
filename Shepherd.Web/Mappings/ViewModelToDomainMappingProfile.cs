using AutoMapper;
using Shepherd.BusinessLogic.Entities;
using Shepherd.Web.ViewModels;

namespace Shepherd.Web.Mappings
{
	public class ViewModelToDomainMappingProfile : Profile
	{
		private const string ProfileNameValue = "ViewModelToDomainMappings";

		public override string ProfileName
		{
			get
			{
				return ProfileNameValue;
			}
		}

		protected override void Configure()
		{
			Mapper.CreateMap<MemberDetailsViewModel, MemberDetails>();
		}
	}
}
