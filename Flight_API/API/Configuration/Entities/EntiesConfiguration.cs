
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Models;

public class FlightConfiguration : IEntityTypeConfiguration<FlightObject>
{
    public void Configure(EntityTypeBuilder<FlightObject> builder)
    {
        builder.HasData(
            new FlightObject
            {
                Flight_No = "",
                Capacity = 150,
                Origin = "Dulles",
                Destination = "Tan Son Nhat",
            },
            new FlightObject
            {
                Flight_No = "",
                Capacity = 180,
                Origin = "Tan Son Nhat",
                Destination = "Dulles",
            });
    }
}

public class PassengerConfiguration : IEntityTypeConfiguration<PassengerObject>
{
    public void Configure(EntityTypeBuilder<PassengerObject> builder)
    {
        builder.HasData(
            new PassengerObject
            {
                Passenger_ID = Guid.NewGuid(),
                FirstName = "Tuan",
                LastName = "Vo",
                Email = "abc@gmail.com",
            },

            new PassengerObject
            {
                Passenger_ID = Guid.NewGuid(),
                FirstName = "Chi",
                LastName = "Le",
                Email = "cba@gmail.com",
            }
        );
    }
}