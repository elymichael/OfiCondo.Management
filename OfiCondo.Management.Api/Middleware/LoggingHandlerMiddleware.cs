namespace OfiCondo.Management.Api.Middleware
{
    using OfiCondo.Management.Application.Exceptions;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    public class LoggingHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.ValidationErrors);
                    break;
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    result = notFoundException.Message;
                    break;
                case Exception ex:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = ex.Message;
                    break;
            }

            if (result == string.Empty)
            {
                result = exception.Message;
            }

            context.Response.StatusCode = (int)httpStatusCode;
            var data = JsonConvert.SerializeObject(new
            {
                StatusCode = (int)httpStatusCode,
                ErrorMessage = result
            });

            return context.Response.WriteAsync(data);
        }
    }
}
