using System.Threading.Tasks;
using Contentment.Api.Domain;
using NUnit.Framework;

namespace Contentment.Api.IntegrationTest.Controllers
{
	[TestFixture]
	public class InfoControllerTest : BaseIntegrationController {

		[Test]
		public async Task GetApiInfo_WhenCalled_ThenShouldReturnVendorContentType() {
			var response = await GetClient().GetAsync("/info");

			var headers = response.Content.Headers;

			Assert.That(headers.Contains("Content-Type"), Is.True);
			Assert.That(headers.ContentType.MediaType, Is.EqualTo(ContentTypes.VENDOR_MIME_TYPE));
		}
	}
}