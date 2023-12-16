
using System.Reflection.Metadata.Ecma335;
using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Service;

public class PassengerService : IPassengerService
{
    public APIdbContext _dbContext;
    public PassengerService(APIdbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    public async Task CreatePassenger(Create_PassengerDTO new_pass)
    {
        var passenger = new PassengerObject
        {
            FirstName = new_pass.FirstName,
            LastName = new_pass.LastName,
            Email = new_pass.Email,
        };

        _dbContext.Passengers.Add(passenger);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<Reponse_PassengerDTO> GetPassenger(int pass_id)
    {
        var pass = await _dbContext.Passengers.FindAsync(pass_id);

        if (pass == null) return null!;

        var result = new Reponse_PassengerDTO
        {
            FirstName = pass.FirstName,
            LastName = pass.LastName,
            Email = pass.Email,
        };
        return result;
    }
    public async Task<IEnumerable<Reponse_PassengerDetailDTO>> GetAllPassenger()
    {
        var flights = await _dbContext.Passengers.ToListAsync();

        var results = flights.Select(p => new Reponse_PassengerDetailDTO
                                        {
                                            FirstName = p.FirstName,
                                            LastName = p.LastName,
                                            Email = p.Email,
                                        }).ToList();

        return results;
    }
    public async Task UpdatePassenger(int pass_id, Update_PassengerDTO new_pass)
    {
        var pass = await _dbContext.Passengers.FindAsync(pass_id);

        if (pass == null) return;
        //update
        {
            pass.FirstName = new_pass.FirstName;
            pass.LastName = new_pass.LastName;
            pass.Email = new_pass.Email;
        }

        await _dbContext.SaveChangesAsync();
    }
    public async Task DeletePassenger(int pass_id)
    {
        var pass = await _dbContext.Passengers.FindAsync(pass_id);

        if (pass == null) return;

        _dbContext.Passengers.Remove(pass);
        await _dbContext.SaveChangesAsync();
    }
}