

// This is the passenger object structuring passenger information and

using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class PassengerObject
{
    [Key]
    [Required(ErrorMessage = "The Passenger ID is required")]
    public string Passenger_ID { get; init; } = string.Empty;

    [Required(ErrorMessage = "The First Name is required")]
    [MaxLength(24)]
    public string FirstName { get; set; } = string.Empty;
    [Required(ErrorMessage = "The Last Name is required")]
    [MaxLength(24)]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "The email is required")]
    [EmailAddress(ErrorMessage = "The email is not valud")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "The flight is required")]
    public FlightObject Flight { get; set; } = new();
    public string Seat { get; set; } = string.Empty;
}