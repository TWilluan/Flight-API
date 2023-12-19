


using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Service;

namespace API.Configuration.Extensions;

public static class WebAppBuilder_AddPersistence
{
    public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<APIdbContext>(options =>
        {
            options.UseMySql(builder.Configuration.GetConnectionString("Default"),
                            new MySqlServerVersion(new Version(8, 0, 31)));
        });

        builder.Services.AddScoped<IFlightService, FlightService>();
        builder.Services.AddScoped<IPassengerService, PassengerService>();
        builder.Services.AddScoped<IBookingService, BookingService>();

        return builder;
    }
}