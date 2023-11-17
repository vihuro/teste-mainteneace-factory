using MediatR;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using TesteMainteneace.Application.UseCases.Logs.CreateLogs;
using TestMainteneace.Api.Middlewares.Models;

namespace TestMainteneace.Api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandleMiddlewares
    {
        private readonly RequestDelegate _next;

        public ErrorHandleMiddlewares(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IMediator meddiator)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                await HandlwExceptionAsync(httpContext, ex, meddiator);
            };
        }

        private static Task HandlwExceptionAsync(HttpContext httpContext, Exception exception, IMediator meddiator)
        {
            var response = httpContext.Response;
            response.ContentType = "application/json";

            var statusCode = HttpStatusCode.BadRequest;

            if (exception.HResult == 404)
            {
                statusCode = HttpStatusCode.NotFound;
            }

            var trace = new StackTrace(exception, true);


            var separetString = exception.Message.Split('\n').Where(x => x != "").ToList();

            var path = string.Empty;
            var column = string.Empty;
            var line = string.Empty;

            for (var i = 0; i < trace.FrameCount; i++)
            {
                if (trace.GetFrame(i).GetFileLineNumber() != 0)
                {
                    path = trace.GetFrame(i).GetFileName();
                    line = trace.GetFrame(i).GetFileColumnNumber().ToString();
                    break;
                }
            }
            meddiator.Send(new CreateLogsRequest(
                Id: Guid.NewGuid(),path,line,statusCode.ToString(),separetString));


            var responseModel = new MiddlewareModel(statusCode.ToString(),
                                                    line,
                                                    path,
                                                    separetString);

            httpContext.Response.StatusCode = Convert.ToInt32(statusCode);

            var result = JsonConvert.SerializeObject(responseModel);
            httpContext.Response.ContentType = "application/json";

            return httpContext.Response.WriteAsync(result);

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandleMiddlewares>();
        }
    }
}
