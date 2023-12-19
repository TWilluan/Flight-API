
using Serilog;

namespace API.Configuration.Extensions;

public static class WebAppBuilder_AddLoggingExtensions
{
    public static WebApplicationBuilder AddLogging(this WebApplicationBuilder builder)
    {
        //Comment this if you don't want to clear the existing log file
        ClearExistingLogFile();
        
        ConfigureSerilog();

        builder.Host.UseSerilog();

        return builder;
    }
    private static void ConfigureSerilog()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("Logs/logs.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }

    private static void ClearExistingLogFile()
    {
        var path = "Logs/logs.txt";

        try
        {
            if (File.Exists(path))
                File.Delete(path);

        } catch (Exception ex) {
            throw new Exception($"Error cleaning a log file at: {path}\n" + 
                                $"Message: {ex.Message}");
        }
    }
}