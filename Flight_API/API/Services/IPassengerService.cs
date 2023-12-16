

using API.DTOs;

namespace API.Service;

public interface IPassengerService
{
    Task CreatePassenger(Create_PassengerDTO new_pass);
    Task<Reponse_PassengerDTO> GetPassenger(int pass_id);
    Task<IEnumerable<Reponse_PassengerDetailDTO>> GetAllPassenger();
    Task UpdatePassenger(int pass_id, Update_PassengerDTO new_pass);
    Task DeletePassenger(int pass_id);
}