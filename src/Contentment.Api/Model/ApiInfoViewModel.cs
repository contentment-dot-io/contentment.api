using System;
using Contentment.Api.Domain;

namespace Contentment.Api.Model
{
	public class ApiInfoViewModel
	{
		public ApiInfoViewModel(ApiInfo apiInfo)
		{
			Version = apiInfo.Version;
		}

		public string Version {get; set;}
	}
}