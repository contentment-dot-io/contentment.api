using System;
using System.Net;
using Contentment.Api.Domain;
using Contentment.Api.Model;
using Contentment.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contentment.Api.Controllers {
	public class ContentController : Controller
	{
		private IContentService _contentService;

		public ContentController(IContentService contentService)
		{
			_contentService = contentService;
		}

		[HttpPost("/content")]
		public JsonResult PostContent([FromBody] ContentCreate content)
		{
			JsonResult result;
			if (ModelState.IsValid) {
				var newContent = _contentService.Create(content);
				result = Json(newContent);
				result.StatusCode = (int)HttpStatusCode.Created;
			}
			else {
				var error = new ClientError(ModelState){
					Code = ErrorCodes.INVALID_CONTENT,
					Description = "Content is invalid"
				};
				result = Json(error);
				result.StatusCode = (int)HttpStatusCode.BadRequest;
			}

			return result;
		}
	}
}