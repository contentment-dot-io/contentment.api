using System;
using Contentment.Api.Model;

namespace Contentment.Api.Services {
	public class ContentService : IContentService
	{
		private readonly IIdGenerator _idGenerator;

		public ContentService(IIdGenerator idGenerator)
		{
			_idGenerator = idGenerator;
		}

		public Content Create(ContentCreate content)
		{
			return new Content{
				Id = _idGenerator.Generate(),
				CreatedDateTime = new DateTime(),
				Body = content.Body,
				Title = content.Title
			};
		}
	}
}