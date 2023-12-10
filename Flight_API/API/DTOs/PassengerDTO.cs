
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;
public class Create_PassengerDTO : DTOs
{
    public Guid Passenger_ID { get; init; }

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

public class Update_PassengerDTO : Create_FlightDTO, DTOs {}

public class Reponse_PassengerDTO : DTOs
{
    [Required(ErrorMessage = "The First Name is required")]
    [MaxLength(24)]
    public string FirstName { get; set; } = string.Empty;
    [Required(ErrorMessage = "The Last Name is required")]
    [MaxLength(24)]
    public string LastName { get; set; } = string.Empty;
    public string Flight_No { get; set; } = string.Empty;
    public string Seat { get; set; } = string.Empty;
}

public class Reponse_PassengerDetailDTO : Reponse_PassengerDTO, DTOs
{
    [Required(ErrorMessage = "The email is required")]
    [EmailAddress(ErrorMessage = "The email is not valud")]
    public string Email { get; set; } = string.Empty;
}