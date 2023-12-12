using System.ComponentModel.DataAnnotations;

namespace API.Models;
// This is the flight object structuring flight information and
// the list of passenger on the flight

public class FlightObject
{
    [Key]
    [MaxLength(5)]
    public string Flight_No { get; init; } = null!;

    [Required]
    public int Capacity { get; init; }
    
    [Required]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "The origin muse have exactly 3 characters)")]
    public string Origin { get; set; } = string.Empty;

    [Required]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "The destination muse have exactly 3 characters")]
    public string Destination { get; set; } = string.Empty;
    public DateTime Time_Ori { get; set; }
    public DateTime Time_Des { get; set; }
    public string Gate { get; set; } = string.Empty;
    public List<PassengerObject> List_Passenger = new();
}