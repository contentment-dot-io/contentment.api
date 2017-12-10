using System;

namespace Contentment.Api.Services
{
	public class GuidIdGenerator : IIdGenerator
	{
		string IIdGenerator.Generate()
		{
			return Guid.NewGuid().ToString();
		}
	}
}