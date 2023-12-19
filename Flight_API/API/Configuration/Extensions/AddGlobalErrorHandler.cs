

using API.Configuration.Middleware;

namespace API.Configuration.Extensions;

public static class WebAppBuilder_AddGlobalErrorHandler
{
    public static WebApplicationBuilder AddGlobalErrorHandler(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<GlobalErrorHandlingOptions>
        (
            builder.Configuration.GetSection("GlobalErrorHandlingOptions")
        );

        builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

        return builder;
    }
}