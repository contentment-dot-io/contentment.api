using Contentment.Api.Model;
using Contentment.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contentment.Api.Controllers
{
	public class InfoController : Controller
	{
		private IApiInfoService _apiInfoService;

		public InfoController(IApiInfoService apiInfoService)
		{
			_apiInfoService = apiInfoService;
		}

		[HttpGet("/info")]
		public JsonResult GetApiInfo() {
			var apiInfo = new ApiInfoViewModel(_apiInfoService.Get());
			var jsonResult = Json(apiInfo);
			jsonResult.ContentType = "application/vnd+contentment+json";
			return jsonResult;
		}
	}
}