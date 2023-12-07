

using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data;

public class APIdbContext : DbContext
{
    public DbSet<FlightObject> Flights {get; set;}
    public DbSet<PassengerObject> Passengers {get; set;}

    public APIdbContext() {}

    public APIdbContext(DbContextOptions<APIdbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new FlightConfiguration());
        modelBuilder.ApplyConfiguration(new PassengerConfiguration());
    }
}