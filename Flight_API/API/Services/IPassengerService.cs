

using API.DTOs;

namespace API.Service;

public interface IPassengerService
{
    Task CreatePassenger(Create_PassengerDTO passenger);
    Task<IEnumerable<Reponse_PassengerDTO>> GetAllPassenger();
    Task<Reponse_PassengerDTO> GetPassenger(Guid pass_id);
    Task UpdatePassenger(Guid pass_id, Update_PassengerDTO passenger);
    Task DeletePassenger(Guid pass_id);
}