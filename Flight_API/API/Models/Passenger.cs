

// This is the passenger object structuring passenger information and

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

/*********************************************************
    Represents a passenger object containing information 
        about a specific passenger and her/his flight.
**********************************************************/

public class PassengerObject : People
{
    [Key]
    public Guid Passenger_ID { get; init; }

    [ForeignKey((nameof(Flight)))]
    public Guid FlightID {get;set;}
    public FlightObject Flight {get;set;} = default!;
    public string Seat { get; set; } = string.Empty;
}