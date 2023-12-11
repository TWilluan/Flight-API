

using System.ComponentModel.DataAnnotations;

namespace API.Contracts.Passengers;

public record Passenger_Reponse
{
    [Required]
    [MaxLength(24)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [MaxLength(24)]
    public string LastName { get; set; } = string.Empty;
    public string Flight_No { get; set; } = string.Empty;
    public string Seat { get; set; } = string.Empty;

    public DateTime LastModifiedDate {get; init;} = DateTime.UtcNow;
}