

namespace API.Models;

/*********************************************************
    Juntion table
    Represents the relationship between passenger 
            and flight object
**********************************************************/

public class PassengerFlight_Mapping
{
    public int PassengerID { get; init; }
    public string FlightNo { get; init; } = null!;

    public PassengerObject Passenger { get; set; } = null!;
    public FlightObject Flight { get; set; } = null!;

    public string? Seat { get; set; }
    public DateTime BookingTime { get; set; }
}