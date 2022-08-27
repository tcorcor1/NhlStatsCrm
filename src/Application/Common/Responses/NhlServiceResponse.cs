using System.Net;

namespace NhlStatsCrm.Application.Common.Responses
{
	public class NhlServiceResponse<T> : ServiceResponseBase<T>
	{
		public NhlServiceResponse (bool isSuccess, HttpStatusCode statusCode, string message, T body) : base(isSuccess, statusCode, message, body)
		{
		}

		public NhlServiceResponse (bool isSuccess, HttpStatusCode statusCode, string message) : base(isSuccess, statusCode, message)
		{
		}

		public NhlServiceResponse (bool isSuccess, T body) : base(isSuccess, body)
		{
		}
	}
}