
using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Service;

public class PassengerService : IPassengerService
{
    private readonly APIdbContext _dbContext;

    public PassengerService(APIdbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreatePassenger(Create_PassengerDTO passenger)
    {
        var pass = new PassengerObject
        {
            Passenger_ID = Guid.NewGuid(),
            FirstName = passenger.FirstName,
            LastName = passenger.LastName,
            Email = passenger.Email,
            Flight_No = passenger.Flight_No,
            Seat = passenger.Seat
        };

        //Add passenger to flight

        _dbContext.Passengers.Add(pass);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<IEnumerable<Reponse_PassengerDTO>> GetAllPassenger()
    {
        var passengers = await _dbContext.Passengers.
                            Select(p => new Reponse_PassengerDTO
                            {
                                FirstName = p.FirstName,
                                LastName = p.LastName,
                                Flight_No = p.Flight_No,
                                Seat = p.Seat,
                            }).ToListAsync();
        
        return passengers;
    }
    public async Task<Reponse_PassengerDTO> GetPassenger(Guid pass_id)
    {
        var pass = await _dbContext.Passengers.
                            Where(p => p.Passenger_ID == pass_id).
                            Select(p => new Reponse_PassengerDTO
                            {
                                FirstName = p.FirstName,
                                LastName = p.LastName,
                                Flight_No = p.Flight_No,
                                Seat = p.Seat,
                            }).FirstOrDefaultAsync();
        
        return pass;
    }
    public async Task UpdatePassenger(Guid pass_id, Update_PassengerDTO passenger)
    {
        var pass = await _dbContext.Passengers.
                            Where(p => p.Passenger_ID == pass_id).
                            FirstAsync();
        //update passenger
        {
            pass.FirstName = passenger.FirstName;
            pass.LastName = passenger.LastName;
            pass.Email = passenger.Email;  
            //TODO: delete and add pass to new flight
            pass.Flight_No = passenger.Flight_No;
            pass.Seat = passenger.Seat;
        }

        await _dbContext.SaveChangesAsync();
    }
    public async Task DeletePassenger(Guid pass_id)
    {
        var pass = await _dbContext.Passengers.
                        Where(p => p.Passenger_ID == pass_id).
                        FirstOrDefaultAsync();
        
        _dbContext.Passengers.Remove(pass);
        await _dbContext.SaveChangesAsync();
    }
}