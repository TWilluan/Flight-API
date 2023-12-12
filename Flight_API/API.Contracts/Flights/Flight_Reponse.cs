

using System.ComponentModel.DataAnnotations;

namespace API.Contracts.Flights;

public record Flight_Reponse
{
    [StringLength(5, MinimumLength = 5, ErrorMessage = "Flight_no must have extractly 5 character")]
    public string Flight_No { get; init; } = null!;

    [StringLength(3, MinimumLength = 3, ErrorMessage = "Origin must have 3 characters")]
    public string Origin { get; set; } = string.Empty;

    [StringLength(3, MinimumLength = 3, ErrorMessage = "Destination must have 3 characters")]
    public string Destination { get; set; } = string.Empty;
    public DateTime Time_Ori { get; set; }
    public DateTime Time_Des { get; set; }
    public string Gate { get; set; } = string.Empty;
    public DateTime LastModifiedDate {get; init;} = DateTime.UtcNow;
}