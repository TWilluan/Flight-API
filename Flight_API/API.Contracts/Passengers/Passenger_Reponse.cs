

using System.ComponentModel.DataAnnotations;

namespace API.Contracts.Passengers;

public record Passenger_Reponse
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? FlightNo { get; set; }
    public string Seat { get; set; } = string.Empty;
}