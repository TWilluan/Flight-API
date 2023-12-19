

using System.ComponentModel.DataAnnotations;

namespace API.Models;

/*********************************************************
    Juntion table
    Represents the relationship between passenger 
            and flight object
**********************************************************/

public class PassengerFlight_Booking
{
    [Key]
    public int PassengerID { get; init; }
    [Key]
    public string FlightNo { get; init; } = null!;

    public PassengerObject Passenger { get; set; } = default!;
    public FlightObject Flight { get; set; } = default!;

    public string? Seat { get; set; }
    public DateTime BookingTime { get; set; }
}