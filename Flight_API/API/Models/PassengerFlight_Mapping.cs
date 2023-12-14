

namespace API.Models;

public class PassengerFlight_Mapping
{
    public Guid PassengerID {get;init;}
    public Guid FlightID{get;init;}

    public PassengerObject Passenger {get;set;} = null!;
    public FlightObject Flight {get;set;} = null!;

    public DateTime BookingTime {get;set;} 
}