using System;
using Contentment.Api.Domain;

namespace Contentment.Api.Model
{
	public class ApiInfoViewModel
	{
		private ApiInfo _apiInfo;

		public ApiInfoViewModel(ApiInfo apiInfo)
		{
			this._apiInfo = apiInfo;
			Version = _apiInfo.Version;
		}

		public string Version {get; set;}
	}
}