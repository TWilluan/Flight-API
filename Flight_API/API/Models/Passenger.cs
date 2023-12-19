

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
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Passenger_ID { get; init; }

    public ICollection<PassengerFlight_Booking> PassengerFlightMapper {get;set;} = default!;
}