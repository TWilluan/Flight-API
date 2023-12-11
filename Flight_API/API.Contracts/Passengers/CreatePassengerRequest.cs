

using System.ComponentModel.DataAnnotations;

namespace API.Contracts.Passengers;

public record CreatePassenger_Request
{
    [Required(ErrorMessage = "The First Name is required")]
    [MaxLength(24)]
    public string FirstName { get; set; } = string.Empty;
    [Required(ErrorMessage = "The Last Name is required")]
    [MaxLength(24)]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "The email is required")]
    [EmailAddress(ErrorMessage = "The email is not valud")]
    public string Email { get; set; } = string.Empty;

    public string Flight_No { get; set; } = string.Empty;
    public string Seat { get; set; } = string.Empty;
}