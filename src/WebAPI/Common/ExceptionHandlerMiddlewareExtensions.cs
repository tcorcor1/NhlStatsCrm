using NhlStatsCrm.WebAPI.Middleware;

namespace NhlStatsCrm.WebAPI.Common
{
	public static class ExceptionHandlerMiddlewareExtensions
	{
		public static void UseExceptionHandlerMiddleware (this IApplicationBuilder app)
		{
			app.UseMiddleware<ExceptionHandlerMiddleware>();
		}
	}
}