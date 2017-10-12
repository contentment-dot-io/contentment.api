using System;
using Contentment.Api.Domain;
using Contentment.Api.Service;
using Moq;
using NUnit.Framework;

namespace Contentment.Api.Test.Services {

	[TestFixture]
	public class ApiInfoServiceTest {

		[Test]
		public void Implements_IApiInfoService() {
			var service = CreateService();

			Assert.That(service, Is.InstanceOf<IApiInfoService>());
		}

		[Test]
		public void Get_WhenCalled_ThenReturnApiInfo() {
			var service = CreateService();

			var apiInfo = service.Get();

			Assert.That(apiInfo, Is.InstanceOf<ApiInfo>());
		}

		[Test]
		public void Get_WhenCalled_ThenRequestVersionFromApiVersion() {
			var version = new Mock<IApiVersion>();
			version.Setup(m => m.Version()).Returns("1.0.0");

			var service = CreateService(apiVersion: version.Object);

			service.Get();

			version.Verify(f => f.Version(), Times.Once());
		}

		[Test]
		public void Get_WhenCalled_ThenSuccessfullyPopulateVersion() {
			const string versionNumber = "1.0.0";
			var version = new Mock<IApiVersion>();
			version.Setup(m => m.Version()).Returns(versionNumber);

			var service = CreateService(apiVersion: version.Object);

			var info = service.Get();

			Assert.That(info.Version, Is.EqualTo(versionNumber));
		}

		private IApiInfoService CreateService(IApiVersion apiVersion = null)
		{
			return new ApiInfoService(apiVersion ?? new Mock<IApiVersion>().Object);
		}
	}
}