

using System.ComponentModel.DataAnnotations;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.DTOs;

public class Create_FlightDTO : DTOs
{
    [Required]
    [MaxLength(5)]
    [MinLength(5)]
    [RegularExpression(@"^[A-Z]{3}\d{2}$", ErrorMessage = "FlightNo must be in format \"AAA00\"")]
    public string FlightNo { get; init; } = null!;
    [Required]
    public int Capacity { get; set; }

    [Required]
    [MaxLength(3)]
    [MinLength(3)]
    public string Origin { get; set; } = string.Empty;

    [Required]
    [MaxLength(3)]
    [MinLength(3)]
    public string Destination { get; set; } = string.Empty;
    public DateTime Time_Ori { get; set; } = DateTime.UtcNow;
    public DateTime Time_Des { get; set; }
    public string Gate { get; set; } = string.Empty;
}

public class Update_FlightDTO : Create_FlightDTO, DTOs {}

public class Reponse_FlightDTO : DTOs
{
    public string FlightNo { get; init; } = null!;
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public DateTime Time_Ori { get; set; }
    public DateTime Time_Des { get; set; }
    public string Gate { get; set; } = string.Empty;
}

public class Reponse_FlightDetailDTO : Reponse_FlightDTO, DTOs
{
    public int Capacity { get; set; }
    public int Current_Pass { get; set; }
}