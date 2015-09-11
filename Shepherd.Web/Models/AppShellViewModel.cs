
namespace Shepherd.Web.Models
{
	public class AppShellViewModel
	{
		public AppSettings Settings { get; set; }

		public AppShellViewModel()
		{
			Settings = new AppSettings();
		}
	}
}