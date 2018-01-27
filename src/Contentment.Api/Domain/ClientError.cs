using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Contentment.Api.Domain {
	public class ClientError
	{
		public ClientError(ModelStateDictionary modelState)
		{
			Detailed = PopulateFromModelState(modelState);
		}

		private static IDictionary<string, IList<ErrorDetail>> PopulateFromModelState(ModelStateDictionary modelState)
		{
			var errors = new Dictionary<string, IList<ErrorDetail>>();

			foreach(var stateEntry in modelState) {
				errors.Add(stateEntry.Key, PopulateErrorDetail(stateEntry.Value));
			}

			return errors;
		}

		private static IList<ErrorDetail> PopulateErrorDetail(ModelStateEntry entry)
		{
			var details = new List<ErrorDetail>();
			foreach (var error in entry.Errors) {
				var detail = new ErrorDetail{
					Message = error.ErrorMessage
				};

				details.Add(detail);
			}

			return details;
		}

		public string Code { get; set; }
		public string Description { get; set; }
		public IDictionary<string, IList<ErrorDetail>> Detailed { get; }

		public class ErrorDetail
		{
			public string Message { get; internal set; }
		}
	}
}