

using API.Configuration.Middleware;
using Microsoft.Extensions.Options;

namespace API.Configuration.Extensions;

public enum ErrorHandlingType
{
    ErrorController,
    CustomMiddleware
}

public class GlobalErrorHandlingOptions
{
    public ErrorHandlingType? ExceptionHandlingType { get; set; }
}

public static class WebAppBuilder_UseGlobalErrorHandling
{
    private static ErrorHandlingType? GetErrorHandlingType(this WebApplication webapp)
    {
        return webapp.Services.GetService<IOptions<GlobalErrorHandlingOptions>>()?
                    .Value.ExceptionHandlingType;
    }

    public static WebApplication UseGlobalErrorHandling(this WebApplication webapp)
    {
        switch (webapp.GetErrorHandlingType())
        {
            case ErrorHandlingType.ErrorController:
                webapp.UseExceptionHandler("/error");
                break;
            case ErrorHandlingType.CustomMiddleware:
                webapp.UseMiddleware<GlobalExceptionHandlingMiddleware>();
                break;
        }
        return webapp;
    }
}