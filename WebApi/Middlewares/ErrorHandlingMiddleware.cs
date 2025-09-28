using System.Net;
using System.Text.Json;
using System;

namespace WebApi.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                Console.WriteLine($"An unhandled exception occurred: {ex.Message}");

                var errorResponse = new
                {
                    httpContext.Response.StatusCode,
                    Message = "Doslo je do neocikvane greske, probajte ponovo",
                    DetailedMessage = ex.Message
                };

                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));

            }
        }
    }
}
