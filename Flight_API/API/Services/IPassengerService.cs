

using API.DTOs;

namespace API.Service;

public interface PassengerService
{
    public Task CreatePassenger(Create_PassengerDTO passenger);
    public Task<IEnumerable<Reponse_PassengerDTO>> GetAllPassenger();
    public Task GetPassenger(Guid pass_id);
    public Task UpdatePassenger(Guid pass_id, Update_PassengerDTO passenger);
    public Task DeletePassenger(Guid pass_id);
}