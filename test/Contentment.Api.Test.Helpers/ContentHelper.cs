using System;
using Contentment.Api.Model;

namespace Contentment.Api.Test.Helpers {
	public class ContentHelper {
		public static ContentCreate ValidContent()
		{
			return new ContentCreate {
				Title = "Valid Title",
				Body = "Valid Body!"
			};
		}

		public static ContentCreate InvalidContent()
		{
			return new ContentCreate();
		}
	}
}