using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Contentment.Api.Model;
using Newtonsoft.Json;
using NUnit.Framework;
using Contentment.Api.Test.Helpers;

namespace Contentment.Api.IntegrationTest.Controllers {
	[TestFixture]
	public class ContentControllerTest : BaseIntegrationController {
		[Test]
		public async Task PostContent_WhenCalledWithValidContent_ThenShouldReturnCreatedContent() {
			var validContent = ContentHelper.ValidContent();
			var content = new StringContent(JsonConvert.SerializeObject(validContent), Encoding.UTF8, "application/json");
			var response = await GetClient().PostAsync("/content", content);
			var jsonString = await response.Content.ReadAsStringAsync();
			dynamic json = JsonConvert.DeserializeObject(jsonString);

			Assert.That(json.title.ToString(), Is.EqualTo(validContent.Title));
			Assert.That(json.body.ToString(), Is.EqualTo(validContent.Body));
			Assert.That(json.id, Is.Not.Null);
			Assert.That(json.createdDateTime, Is.Not.Null);
		}
	}
}