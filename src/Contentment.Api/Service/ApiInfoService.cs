using Contentment.Api.Domain;

namespace Contentment.Api.Service {
	public class ApiInfoService : IApiInfoService
	{
		private IApiVersion _apiVersion;

		public ApiInfoService(IApiVersion apiVersion)
		{
			this._apiVersion = apiVersion;
		}

		public ApiInfo Get()
		{
			return new ApiInfo{
				Version = _apiVersion.Version()
			};
		}
	}
}