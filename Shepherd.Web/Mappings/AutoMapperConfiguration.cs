using AutoMapper;

namespace Shepherd.Web.Mappings
{
	public class AutoMapperConfiguration
	{
		public static void Configure()
		{
			Mapper.Initialize(_ =>
			{
				_.AddProfile<DomainToViewModelMappingProfile>();
				_.AddProfile<ViewModelToDomainMappingProfile>();
			});
		}
	}
}