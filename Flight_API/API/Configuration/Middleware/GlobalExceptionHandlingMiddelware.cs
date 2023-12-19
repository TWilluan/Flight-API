


using System.Net;
using System.Text.Json;
using API.Configuration.Exceptions;
using Microsoft.AspNetCore.Mvc;
using mvc.Configurations.Exceptions;

namespace API.Configuration.Middleware;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
    public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try{
            await next(context);
        } catch(Exception exception) {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

        var message = "A problem is occured while handling your request";
        var stacktrace = string.Empty;

        switch(exception)
        {
            case BadRequestException:
                statusCode = HttpStatusCode.BadRequest;
                message = exception.Message;
                stacktrace = exception.StackTrace;
                break;
            case NotFoundException:
                statusCode = HttpStatusCode.NotFound;
                message = exception.Message;
                stacktrace = exception.StackTrace;
                break;
            case NotImplementedApiException:
                statusCode = HttpStatusCode.NotImplemented;
                message = exception.Message;
                stacktrace = exception.StackTrace;
                break;
            case UnauthorizedAccessApiException:
                statusCode = HttpStatusCode.Unauthorized;
                message = exception.Message;
                stacktrace = exception.StackTrace;
                break;
        }

        _logger.LogError(exception, $"An error occured: {exception.Message}");

        ProblemDetails problem = new()
        {
            Status = (int)statusCode,
            Type = "[Custome Middleware] Error",
            Title = message,
            Detail = stacktrace
        };

        var resultJson = JsonSerializer.Serialize(problem);

        var reponse = context.Response;
        
        reponse.StatusCode = (int) statusCode;

        reponse.ContentType = "application/json";

        await reponse.WriteAsync(resultJson);

    }
}