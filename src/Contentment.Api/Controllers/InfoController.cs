using Contentment.Api.Model;
using Contentment.Api.Service;
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
			return Json(apiInfo);
		}
	}
}