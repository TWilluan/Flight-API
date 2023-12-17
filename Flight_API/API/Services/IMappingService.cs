

using API.DTOs;
using API.Models;

namespace API.Service;

public interface IMappingService
{
    Task<PassengerFlight_Mapping> Booking(int pass_id, string FlightNo, string? seat);
    Task<PassengerFlight_Mapping> GetBooking(int pass_id, string FlightNo);    
    Task ChangeSeat(int pass_id, string FlightNo, string Seat);
    Task CancelBooking(int pass_id, string FlightNo);

}