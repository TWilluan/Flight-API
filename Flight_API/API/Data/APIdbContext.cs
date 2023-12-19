

using Microsoft.EntityFrameworkCore;
using API.Models;
using System.Configuration;

namespace API.Data;

public class APIdbContext : DbContext
{
    public DbSet<FlightObject> Flights {get; set;}
    public DbSet<PassengerObject> Passengers {get; set;}
    public DbSet<PassengerFlight_Booking> PassengerFlightMappings {get;set;}

    public APIdbContext() {}

    public APIdbContext(DbContextOptions<APIdbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PassengerFlight_Booking>().
            HasKey(fp => new {fp.FlightNo, fp.PassengerID});

        modelBuilder.Entity<PassengerFlight_Booking>()
            .HasOne(fp => fp.Flight)
            .WithMany(f => f.PassengerFlightMapper)
            .HasForeignKey(fp => fp.FlightNo);

        modelBuilder.Entity<PassengerFlight_Booking>()
            .HasOne(fp => fp.Passenger)
            .WithMany(p => p.PassengerFlightMapper)
            .HasForeignKey(fp => fp.PassengerID);

        modelBuilder.ApplyConfiguration(new FlightConfiguration());
        modelBuilder.ApplyConfiguration(new PassengerConfiguration());
    }
}