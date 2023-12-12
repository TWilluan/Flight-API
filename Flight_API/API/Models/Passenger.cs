

// This is the passenger object structuring passenger information and

using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class PassengerObject
{
    [Key]
    public Guid Passenger_ID { get; init; }

    [Required]
    [MaxLength(24)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [MaxLength(24)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress(ErrorMessage = "The email is not valid")]
    public string Email { get; set; } = string.Empty;
    
    public string Flight_No { get; set; } = string.Empty;
    public string Seat { get; set; } = string.Empty;
}