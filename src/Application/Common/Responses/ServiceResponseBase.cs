using System.Net;

namespace NhlStatsCrm.Application.Common.Responses
{
	public abstract class ServiceResponseBase<T>
	{
		public bool IsSuccess { get; set; }
		public HttpStatusCode StatusCode { get; set; }
		public string? Message { get; set; }
		public T? Body { get; set; }

		public ServiceResponseBase (bool isSuccess, HttpStatusCode statusCode, string message, T body)
		{
			IsSuccess = isSuccess;
			StatusCode = statusCode;
			Message = message;
			Body = body;
		}

		public ServiceResponseBase (bool isSuccess, HttpStatusCode statusCode, string message)
		{
			IsSuccess = isSuccess;
			StatusCode = statusCode;
			Message = message;
		}

		public ServiceResponseBase (bool isSuccess, T body)
		{
			IsSuccess = isSuccess;
			Body = body;
		}
	}

	public abstract class ServiceResponseBase
	{
		public HttpStatusCode StatusCode { get; set; }
		public bool IsSuccess { get; set; }
		public string? Message { get; set; }
	}
}