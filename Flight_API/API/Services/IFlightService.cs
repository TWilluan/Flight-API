

using System.Runtime.CompilerServices;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Service;

public interface IFlightService
{
    Task CreateFlight(Create_FlightDTO flight);
    Task<Reponse_FlightDTO> GetFlight(string FlightNo);
    Task<IEnumerable<Reponse_FlightDetailDTO>> GetAllFlight();
    Task UpdateFlight(string FlightNo, Update_FlightDTO flight);
    Task DeleteFlight(string FlightNo);
}