using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace Contentment.Api.IntegrationTest.Controllers
{
	[TestFixture]
	public class InfoControllerTest {

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

		[Test]
		public async Task GetApiInfo_WhenCalled_ThenShouldReturnVendorContentType() {
			var response = await _client.GetAsync("/info");

			var headers = response.Content.Headers;

			Assert.That(headers.Contains("Content-Type"), Is.True);
			Assert.That(headers.ContentType.MediaType, Is.EqualTo("application/vnd+contentment+json"));
		}
	}
}