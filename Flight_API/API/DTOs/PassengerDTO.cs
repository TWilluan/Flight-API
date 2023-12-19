
using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.DTOs;
public class Create_PassengerDTO : DTOs
{
    [Required]
    [MaxLength(24)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(24)]
    public string LastName { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;
}

public class Update_PassengerDTO : Create_PassengerDTO, DTOs { }

public class Reponse_PassengerDTO : DTOs
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
}

public class Reponse_PassengerDetailDTO : Reponse_PassengerDTO, DTOs
{
    public int Passenger_ID { get; init; }
}