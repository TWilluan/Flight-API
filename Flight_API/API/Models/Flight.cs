using System.ComponentModel.DataAnnotations;

namespace API.Models;

/*********************************************************
    Represents a flight object containing information 
        about a specific flight.
**********************************************************/
public class FlightObject
{
    [Key]
    [MaxLength(5)]
    [MinLength(5)]
    public string FlightNo {get; init;} = null!;
    
    [Required]
    public int Capacity {get; set;}
    public int Current_Pass {get;set;} = 0;
    
    [Required]
    [MaxLength(3)]
    [MinLength(3)]
    public string Origin { get; set; } = string.Empty;

    [Required]
    [MaxLength(3)]
    [MinLength(3)]
    public string Destination { get; set; } = string.Empty;
    public DateTime Time_Ori { get; set; }
    public DateTime Time_Des { get; set; }
    public string Gate { get; set; } = string.Empty;
    public ICollection<PassengerFlight_Mapping> PassengerFlightMapper { get;set;} = default!;
}