using System.ComponentModel.DataAnnotations;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using NhlStatsCrm.Application.Common.Exceptions;

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
			catch (Exception exception)
			{
				var response = context.Response;
				response.ContentType = "application/json";
				string errorMessage;

				switch (exception)
				{
					case DynamicsNotFoundException ex:
						response.StatusCode = (int)HttpStatusCode.NotFound;
						errorMessage = exception.Message;
						break;

					case ArgumentException ex:
						response.StatusCode = (int)HttpStatusCode.BadRequest;
						errorMessage = exception.Message;
						break;

					case FaultException<OrganizationServiceFault> ex:
						response.StatusCode = (int)HttpStatusCode.BadRequest;
						errorMessage = ((FaultException<OrganizationServiceFault>)exception).Detail.InnerFault.InnerFault.Message;
						break;

					default:
						response.StatusCode = (int)HttpStatusCode.InternalServerError;
						errorMessage = exception.Message;
						break;
				}

				var errorResponse = JsonConvert.SerializeObject(new { errorMessage = errorMessage }); ;

				await response.WriteAsync(errorResponse);
			}
		}
	}
}