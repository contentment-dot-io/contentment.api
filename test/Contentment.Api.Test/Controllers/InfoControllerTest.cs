using System;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Contentment.Api.Controllers;
using Contentment.Api.Model;
using Moq;
using Contentment.Api.Service;
using Contentment.Api.Domain;

namespace Contentment.Api.Test.Controllers {

	[TestFixture]
	public class InfoControllerTest {
	
		[Test]
		public void InfoController_ImplementsController() {
			var controller = CreateController();

			Assert.That(controller, Is.InstanceOf<Controller>());
		}

		[Test]
		public void GetApiInfo_WhenCalled_ThenReturnJsonResult() {
			var controller = CreateController();

			var result = controller.GetApiInfo();

			Assert.That(result, Is.InstanceOf<JsonResult>());
		}

		[Test]
		public void GetApiInfo_WhenCalled_ThenReturnApiInfoModel() {
			var controller = CreateController();

			var result = controller.GetApiInfo();
			var model = result.Value;

			Assert.That(model, Is.InstanceOf<ApiInfoViewModel>());
		}

		[Test]
		public void GetApiInfo_WhenCalled_ThenCallApiInfoServiceGet() {
			var apiInfoService = new Mock<IApiInfoService>();
			apiInfoService.Setup(m => m.Get()).Returns(new ApiInfo());

			var controller = CreateController(apiInfoService: apiInfoService.Object);

			var result = controller.GetApiInfo();

			apiInfoService.Verify(f => f.Get(), Times.Once());
		}

		[Test]
		public void GetApiInfo_WhenCalled_ThenModelShouldBePopulatedWithVersionFromApiInfoService() {
			const string version = "2.1.3";
			var apiInfoService = new Mock<IApiInfoService>();
			apiInfoService.Setup(m => m.Get()).Returns(new ApiInfo{ Version = version});

			var controller = CreateController(apiInfoService: apiInfoService.Object);

			var result = controller.GetApiInfo();

			var apiInfo = result.Value as ApiInfoViewModel;

			Assert.That(apiInfo, Is.Not.Null);
			Assert.That(apiInfo.Version, Is.EqualTo(version));
		}

		private InfoController CreateController(IApiInfoService apiInfoService = null)
		{
			var mockApiInfoService = new Mock<IApiInfoService>();
			mockApiInfoService.Setup(m => m.Get()).Returns(new ApiInfo());
			return new InfoController(apiInfoService ?? mockApiInfoService.Object);
		}
	}
}