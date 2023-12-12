

using System.ComponentModel.DataAnnotations;

namespace API.Contracts.Flights;

public record Flight_Reponse
{
    public string FlightNo { get; init; } = null!;
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public DateTime Time_Ori { get; set; }
    public DateTime Time_Des { get; set; }
    public string Gate { get; set; } = string.Empty;
}