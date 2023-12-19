

namespace API.Configuration.Extensions;

public static class WebAppBuilder_AddAutoMapper
{
    public static WebApplicationBuilder AddMapper(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        return builder;
    }
}