
using API.Models;

namespace API.DTOs;

public class Reponse_BookingDTO
{
    public int PassengerID { get; init; }
    public string FlightNo { get; init; } = null!;
    public string Seat { get; set; } = string.Empty;
    public DateTime BookingTime { get; set; }
}