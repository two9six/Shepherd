using System.Configuration;

namespace Shepherd.Web.Models
{
	public class AppSettings
	{
		public string BaseServiceUrl { get; private set; }
		public string EnvironmentName { get; private set; }
		public string TokenStorageKey { get; private set; }

		public AppSettings()
		{
			BaseServiceUrl = ConfigurationManager.AppSettings["BaseServiceUrl"];
			EnvironmentName = ConfigurationManager.AppSettings["EnvironmentName"];
			TokenStorageKey = ConfigurationManager.AppSettings["TokenStorageKey"];
		}
	}
}