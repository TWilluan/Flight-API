
using API.Models;

namespace API.DTOs;

public class Reponse_BookingDTO
{
    public int PassengerID { get; init; }
    public string FlightNo { get; init; } = null!;

    public PassengerObject Passenger { get; set; } = default!;
    public FlightObject Flight { get; set; } = default!;

    public string? Seat { get; set; }
    public DateTime BookingTime { get; set; }
}