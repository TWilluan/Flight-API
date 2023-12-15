

namespace API.Models;

public class PassengerFlight_Mapping
{
    public int PassengerID {get;init;}
    public string FlightNo{get;init;} = null!;

    public PassengerObject Passenger {get;set;} = null!;
    public FlightObject Flight {get;set;} = null!;

    public DateTime BookingTime {get;set;} 
}