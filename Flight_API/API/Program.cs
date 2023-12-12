

using API.Data;
using API.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddScoped<IFlightService, FlightService>();
    builder.Services.AddScoped<IPassengerService, PassengerService>();

    builder.Services.AddDbContext<APIdbContext>(options =>
        {
            options.UseMySql(builder.Configuration.GetConnectionString("Default"),
                            new MySqlServerVersion(new Version(8, 0, 31)));
        });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
