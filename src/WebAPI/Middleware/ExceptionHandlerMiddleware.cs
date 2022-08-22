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

				switch (exception)
				{
					case DynamicsNotFoundException ex:
						response.StatusCode = (int)HttpStatusCode.NotFound;
						break;

					case ArgumentException ex:
						response.StatusCode = (int)HttpStatusCode.BadRequest;
						break;

					//case FaultException<OrganizationServiceFault> ex:
					//	response.StatusCode = (int)HttpStatusCode.BadRequest;
					//	break;

					default:
						response.StatusCode = (int)HttpStatusCode.InternalServerError;
						break;
				}

				var errorResponse = JsonConvert.SerializeObject(new { errorMessage = exception.Message });

				await response.WriteAsync(errorResponse);
			}
		}
	}
}