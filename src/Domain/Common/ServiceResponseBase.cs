namespace Domain.Common
{
	public abstract class ServiceResponseBase<T>
	{
		public HttpStatusCode StatusCode { get; set; }
		public bool IsSuccessStatusCode { get; set; }
		public string? StatusMessage { get; set; }
		public T? Body { get; set; }
	}

	public abstract class ServiceResponseBase
	{
		public HttpStatusCode StatusCode { get; set; }
		public bool IsSuccessStatusCode { get; set; }
		public string? StatusMessage { get; set; }
	}
}