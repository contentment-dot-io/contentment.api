using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using Contentment.Api.Controllers;
using Contentment.Api.Domain;
using Contentment.Api.Model;
using Contentment.Api.Services;
using Contentment.Api.Test.Helpers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Contentment.Api.Test.Controllers {
	[TestFixture]
	public class ContentControllerTest {

		[Test]
		public void ContentController_ImplementsController() {
			var controller = CreateController();

			Assert.That(controller, Is.InstanceOf<Controller>());
		}

		[Test]
		public void PostContent_WhenCalledWithValidContent_ThenReturnJsonResult() {
			var controller = CreateController();
			var content = ContentHelper.ValidContent();

			var result = controller.PostContent(content);

			Assert.That(result, Is.InstanceOf<JsonResult>());
		}

		[Test]
		public void PostContent_WhenCalledWithValidContent_ThenReturn201Response() {
			var controller = CreateController();
			var content = ContentHelper.ValidContent();

			var result = controller.PostContent(content);

			Assert.That(result.StatusCode, Is.EqualTo((int)HttpStatusCode.Created));
		}

		[Test]
		public void PostContent_WhenCalledWithValidContent_ThenCallIContentService() {
			var mockService = new Mock<IContentService>();
			var controller = CreateController(mockService.Object);
			var content = ContentHelper.ValidContent();

			controller.PostContent(content);

			mockService.Verify(f => f.Create(content), Times.Once);
		}

		[Test]
		public void PostContent_WhenCalledWithValidContent_ThenReturnContentFromIContentService() {
			var content = ContentHelper.ValidContent();
			const string expectedId = "qwerty";
			var expectedCreatedDateTime = new DateTime(2017,12,19,6,49,0);
			var mockService = new Mock<IContentService>();
			mockService.Setup(m => m.Create(content)).Returns(
				new Content {
					Id = expectedId,
					Title = content.Title,
					Body = content.Body,
					CreatedDateTime = expectedCreatedDateTime
				}
			);
			var controller = CreateController(mockService.Object);

			var result = controller.PostContent(content);

			var newContent = result.Value as Content;

			Assert.That(newContent, Is.Not.Null);
			Assert.That(newContent.Id, Is.EqualTo(expectedId));
			Assert.That(newContent.CreatedDateTime, Is.EqualTo(expectedCreatedDateTime));
			Assert.That(newContent.Title, Is.EqualTo(content.Title));
			Assert.That(newContent.Body, Is.EqualTo(content.Body));
		}

		[Test]
		public void PostContent_WhenCalledWithoutRequiredFields_ThenReturn400Error() {
			var invalidContent = ContentHelper.InvalidContent();
			var controller = CreateController();

			ValidateModel(invalidContent, controller);

			var result = controller.PostContent(invalidContent);

			Assert.That(result.StatusCode, Is.EqualTo((int)HttpStatusCode.BadRequest));
		}

		[Test]
		public void PostContent_WhenCalledWithoutRequiredFields_ThenReturnClientErrorJson() {
			var invalidContent = ContentHelper.InvalidContent();
			var controller = CreateController();

			ValidateModel(invalidContent, controller);

			var result = controller.PostContent(invalidContent);
			var error = result.Value as ClientError;

			Assert.That(error, Is.Not.Null);
		}

		[Test]
		public void PostContent_WhenCalledWithoutRequiredFields_ThenReturnPopulatedClientErrorJson() {
			const int expectedErrorCount = 2;
			var invalidContent = ContentHelper.InvalidContent();
			var controller = CreateController();

			ValidateModel(invalidContent, controller);

			var result = controller.PostContent(invalidContent);
			var error = result.Value as ClientError;

			Assert.That(error.Code, Is.EqualTo(ErrorCodes.INVALID_CONTENT));
			Assert.That(error.Description, Is.EqualTo("Content is invalid"));

			var details = error.Detailed;

			Assert.That(details.Count, Is.EqualTo(expectedErrorCount));
			Assert.That(details["Title"][0].Message, Is.EqualTo("The Title field is required."));
			Assert.That(details["Body"][0].Message, Is.EqualTo("The Body field is required."));
		}

		private ContentController CreateController(IContentService contentService = null)
		{
			return new ContentController(contentService ?? new Mock<IContentService>().Object);
		}

		private static void ValidateModel(object model, Controller controller)
		{
			var validationContext = new ValidationContext(model, null, null);
			var validationResults = new List<ValidationResult>();
			Validator.TryValidateObject(model, validationContext, validationResults);

			foreach (var validationResult in validationResults)
			{
				controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
			}
		}
	}
}