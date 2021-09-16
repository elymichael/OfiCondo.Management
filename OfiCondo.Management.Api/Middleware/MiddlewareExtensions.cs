namespace OfiCondo.Management.Api.Middleware
{
    using Microsoft.AspNetCore.Builder;
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomLoggingHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingHandlerMiddleware>();
        }
    }
}
