
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
                Flight_No = "AYE35",
                Capacity = 150,
                Origin = "DUL",
                Destination = "TSA",
            },
            new FlightObject
            {
                Flight_No = "EYA23",
                Capacity = 180,
                Origin = "TSA",
                Destination = "DUL",
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
                Flight_No = "AYE35"
            },

            new PassengerObject
            {
                Passenger_ID = Guid.NewGuid(),
                FirstName = "Chi",
                LastName = "Le",
                Email = "cba@gmail.com",
                Flight_No = "EYA23"
            }
        );
    }
}