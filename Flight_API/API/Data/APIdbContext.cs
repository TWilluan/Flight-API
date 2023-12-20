

using Microsoft.EntityFrameworkCore;
using API.Models;
using System.Configuration;

namespace API.Data;

public class APIdbContext : DbContext
{
    public DbSet<FlightObject> Flights { get; set; }
    public DbSet<PassengerObject> Passengers { get; set; }
    public DbSet<PassengerFlight_Booking> PassengerFlightMappings { get; set; }

    public APIdbContext() { } // fix issue cannot create dbContext

    public APIdbContext(DbContextOptions<APIdbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PassengerFlight_Booking>().
            HasKey(fp => new { fp.FlightNo, fp.PassengerID });

        //  decalre many-to-many relationship between flight and passenger
        modelBuilder.Entity<PassengerFlight_Booking>()
            .HasOne(fp => fp.Flight)
            .WithMany(f => f.PassengerFlightMapper)
            .HasForeignKey(fp => fp.FlightNo);

        modelBuilder.Entity<PassengerFlight_Booking>()
            .HasOne(fp => fp.Passenger)
            .WithMany(p => p.PassengerFlightMapper)
            .HasForeignKey(fp => fp.PassengerID);

        //  Seeding data to flight and passenger table
        modelBuilder.ApplyConfiguration(new FlightConfiguration());
        modelBuilder.ApplyConfiguration(new PassengerConfiguration());
    }
}