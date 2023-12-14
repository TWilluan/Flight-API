
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Models;
using Pomelo.EntityFrameworkCore.MySql.Query.Internal;

public class FlightConfiguration : IEntityTypeConfiguration<FlightObject>
{
    public void Configure(EntityTypeBuilder<FlightObject> builder)
    {
        builder.HasData(
            new FlightObject
            {
                FlightID = Guid.NewGuid(),
                FlightNo = "AYE35",
                Capacity = 150,
                Origin = "DUL",
                Destination = "TSA",
                Time_Ori = DateTime.Now
            },
            new FlightObject
            {
                FlightID = Guid.NewGuid(),
                FlightNo = "EYA23",
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
                Email = "abc@gmail.com"
            },

            new PassengerObject
            {
                Passenger_ID = Guid.NewGuid(),
                FirstName = "Chi",
                LastName = "Le",
                Email = "cba@gmail.com"
            }
        );
    }
}