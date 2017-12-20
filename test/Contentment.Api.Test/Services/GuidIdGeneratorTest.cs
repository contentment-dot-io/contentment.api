using System;
using Contentment.Api.Services;
using NUnit.Framework;

namespace Contentment.Api.Test.Services
{
	[TestFixture]
	public class GuidIdGeneratorTest {
		[Test]
		public void SnowflakeIdGenerator_ImplementsIIdGenerator() {
			var generator = CreateGenerator();

			Assert.That(generator, Is.InstanceOf<IIdGenerator>());
		}

		private GuidIdGenerator CreateGenerator()
		{
			return new GuidIdGenerator();
		}
	}
}