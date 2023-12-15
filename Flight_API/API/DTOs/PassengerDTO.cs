
using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.DTOs;
public class Create_PassengerDTO : DTOs
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

public class Update_PassengerDTO : Create_PassengerDTO, DTOs { }

public class Reponse_PassengerDTO : DTOs
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? FlightNo { get; set; }
    public string Seat { get; set; } = string.Empty;
}

public class Reponse_PassengerDetailDTO : Reponse_PassengerDTO, DTOs
{
    public IEnumerable<FlightObject>? flights {get;set;}
}