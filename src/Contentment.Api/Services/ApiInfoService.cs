using Contentment.Api.Domain;

namespace Contentment.Api.Services {
	public class ApiInfoService : IApiInfoService
	{
		private readonly IApiVersion _apiVersion;

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