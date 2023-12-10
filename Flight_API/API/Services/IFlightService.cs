

using API.DTOs;

namespace API.Service;

public interface IFlightService
{
    Task CreateFlight(Create_FlightDTO flight);
    Task UpdateFlight(string flight_no, Update_FlightDTO flight);
    Task<IEnumerable<Reponse_FlightDTO>> GetAllFlight();
    Task GetFlight(string flight_no);
    Task DeleteFlight(string flight_no);
}