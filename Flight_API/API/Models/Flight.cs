using System.ComponentModel.DataAnnotations;

namespace API.Models;
// This is the flight object structuring flight information and
// the list of passenger on the flight

public class FlightObject
{
    [Key]
    [MaxLength(5)]
    public string? Flight_No { get; init; }

    [Required(ErrorMessage = "Flight's Capacity is required")]
    public int Capacity { get; init; }
    
    [Required(ErrorMessage = "Origin is required")]
    [MaxLength(3)]
    public string Origin { get; set; } = string.Empty;

    [Required(ErrorMessage = "Destination is required")]
    [MaxLength(3)]
    public string Destination { get; set; } = string.Empty;
    public DateTime Time_Ori { get; set; }
    public DateTime Time_Des { get; set; }
    public string Gate { get; set; } = string.Empty;
    public List<PassengerObject> list_passenger = new();
}