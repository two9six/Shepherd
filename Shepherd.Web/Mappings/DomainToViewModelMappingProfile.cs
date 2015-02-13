using AutoMapper;
using Shepherd.BusinessLogic.Entities;
using Shepherd.Web.ViewModels;

namespace Shepherd.Web.Mappings
{
	public class DomainToViewModelMappingProfile : Profile
	{
		private const string ProfileNameValue = "DomainToViewModelMappings";

		public override string ProfileName
		{
			get
			{
				return ProfileNameValue;
			}
		}

		protected override void Configure()
		{
			Mapper.CreateMap<MemberDetails, MemberDetailsViewModel>();
		}
	}
}