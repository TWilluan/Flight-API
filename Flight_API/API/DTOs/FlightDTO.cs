

using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class Create_FlightDTO : DTOs
{
    [StringLength(5, MinimumLength = 5, ErrorMessage = "Flight_no must have extractly 5 character")]
    public string? Flight_no { get; init; }
    public int Capacity { get; set; }

    [StringLength(3, MinimumLength = 3, ErrorMessage = "Origin must have 3 characters")]
    public string Origin { get; set; } = string.Empty;

    [StringLength(3, MinimumLength = 3, ErrorMessage = "Destination must have 3 characters")]
    public string Destination { get; set; } = string.Empty;
    public DateTime Time_Ori { get; set; }
    public DateTime Time_Des { get; set; }
    public string Gate { get; set; } = string.Empty;
}

public class Update_FlightDTO : Create_FlightDTO, DTOs { }

public class Reponse_FlightDTO : DTOs
{
    [StringLength(5, MinimumLength = 5, ErrorMessage = "Flight_no must have extractly 5 character")]
    public string? flight_no { get; init; }

    [StringLength(3, MinimumLength = 3, ErrorMessage = "Origin must have 3 characters")]
    public string Origin { get; set; } = string.Empty;

    [StringLength(3, MinimumLength = 3, ErrorMessage = "Destination must have 3 characters")]
    public string Destination { get; set; } = string.Empty;
    public DateTime Time_Ori { get; set; }
    public DateTime Time_Des { get; set; }
    public string Gate { get; set; } = string.Empty;
}

public class Reponse_FlightDetailDTO : Reponse_FlightDTO, DTOs
{
    public int Capacity { get; set; }
}