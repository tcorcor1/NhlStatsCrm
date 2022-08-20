using System.ServiceModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Xrm.Sdk;

namespace NhlStatsCrm.WebAPI.Middleware
{
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionHandlerMiddleware (RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke (HttpContext context)
		{
			try
			{
				await _next.Invoke(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
			}
		}

		private async Task HandleExceptionMessageAsync (HttpContext context, Exception exception)
		{
			try
			{
				await _next(context);
			}
			catch (Exception error)
			{
				var response = context.Response;
				response.ContentType = "application/json";

				switch (error)
				{
					// TODO: need to find way to handle other dataverse fault situations
					case FaultException<OrganizationServiceFault> ex:
						response.StatusCode = (int)HttpStatusCode.NotFound;
						break;

					case ArgumentException ex:
						response.StatusCode = (int)HttpStatusCode.BadRequest;
						break;

					case ValidationException ex:
						response.StatusCode = (int)HttpStatusCode.BadRequest;
						break;

					default:
						response.StatusCode = (int)HttpStatusCode.InternalServerError;
						break;
				}

				var errorResponse = JsonConvert.SerializeObject(new { errorMessage = error.Message, errorCode = error.HResult });

				await response.WriteAsync(errorResponse);
			}
		}
	}
}