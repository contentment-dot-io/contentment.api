using System.ComponentModel.DataAnnotations;

namespace Contentment.Api.Model {
	public class ContentCreate
	{
		[Required]
		public string Title { get; set; }
		[Required]
		public string Body { get; set; }
	}
}