using System;
using Contentment.Api.Domain;
using NUnit.Framework;

namespace Contentment.Api.Test.Domain {
	[TestFixture]
	public class ApiVersionTest {
		[Test]
		public void Implements_IApiVersion() {
			var version = CreateVersion();

			Assert.That(version, Is.InstanceOf<IApiVersion>());
		}

		private ApiVersion CreateVersion()
		{
			return new ApiVersion();
		}
	}
}