

using System.ComponentModel.DataAnnotations;

namespace API.Contracts.Passengers;

public record CreatePassenger_Request
{
    [Required]
    [MaxLength(24)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(24)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty + "@gmail.com";
    [Required]
    public Guid FlightID { get; set; }
    public string? FlightNo { get; set; }
    public string Seat { get; set; } = string.Empty;
}