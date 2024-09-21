using System.Net;

namespace WeatherApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext); // Pass through to the next middleware
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex); // Catch the exception
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Log the exception (you could add your logger here)
            Console.WriteLine($"Something went wrong: {exception.Message}");

            // Respond with 500 if it's not an authentication issue
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Something went wrong on the server!"
            }.ToString());
        }
    }

}
