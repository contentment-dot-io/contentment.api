using System.Reflection;

namespace Contentment.Api.Domain {
	public class ApiVersion : IApiVersion
	{
		public string Version()
		{
			var assembly = Assembly.GetEntryAssembly();
			var version = assembly.GetName().Version;
			return version.ToString();
		}
	}
}