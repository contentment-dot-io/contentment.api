using System;

namespace Contentment.Api.Model {
	public class Content : ContentCreate
	{
		public string Id { get; set; }
		public DateTime CreatedDateTime { get; set; }
	}
}