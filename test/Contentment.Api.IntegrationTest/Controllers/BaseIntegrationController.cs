using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace Contentment.Api.IntegrationTest.Controllers {
	public abstract class BaseIntegrationController {
		private HttpClient _client;

		[SetUp]
		public void SetUp() {
			var builder = new WebHostBuilder()
								.UseContentRoot(@"../../../../../src/Contentment.Api")
								.UseEnvironment("Development")
								.UseStartup<Contentment.Api.Startup>();
			var server = new TestServer(builder);
			_client = server.CreateClient();
		}

		protected HttpClient GetClient() {
			return _client;
		}
	}
}