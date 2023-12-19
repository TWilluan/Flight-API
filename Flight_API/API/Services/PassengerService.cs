
using System.Reflection.Metadata.Ecma335;
using API.Configuration.Exceptions;
using API.Data;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API.Service;

public class PassengerService : IPassengerService
{
    private readonly APIdbContext _dbContext;
    private readonly IMapper _mapper;
    public PassengerService(APIdbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<Reponse_PassengerDTO> CreatePassenger(Create_PassengerDTO new_pass)
    {
        var passenger = _mapper.Map<PassengerObject>(new_pass);

        if (_dbContext.Passengers.Any(p =>
                p.FirstName == passenger.FirstName &&
                p.LastName == passenger.LastName &&
                p.Email == passenger.Email))
                { //    check if there are duplicate passengers
                    throw new BadRequestApiException("The passenger's information is already existed in database");
                }

        _dbContext.Passengers.Add(passenger);

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<Reponse_PassengerDTO>(passenger);
    }

    public async Task<Reponse_PassengerDTO> GetPassenger(int pass_id)
    {
        var pass = await _dbContext.Passengers.FindAsync(pass_id);

        if (pass == null)
        {
            throw new NotFoundApiException($"Passenger with ID {pass_id} doesn't exist");
        }

        return _mapper.Map<Reponse_PassengerDTO>(pass);
    }

    public async Task<IEnumerable<Reponse_PassengerDetailDTO>> GetAllPassenger()
    {
        var passengers = await _dbContext.Passengers.ToListAsync();

        if (passengers == null)
        { //    check if there is a passenger in database
            throw new NotFoundApiException("There is no passenger in database");
        }

        var results = passengers.Select(p => 
                                    _mapper.Map<Reponse_PassengerDetailDTO>(p))
                                    .ToList();

        return results;
    }

    public async Task<IEnumerable<Reponse_FlightDTO>> GetAllFlights_PassengerHas(int id)
    {
        var passenger = await _dbContext.Passengers.FindAsync(id);

        if (passenger == null)
        {
            throw new NotFoundApiException($"Passenger with ID {id} doesn't exists in database");
        }

        var flights = passenger.PassengerFlightMapper.Select(f =>
                               _mapper.Map<Reponse_FlightDTO>(f)).ToList();

        return flights ?? throw new NotFoundApiException($"Passenger with ID {id} doesn't has any flight");
    }

    public async Task UpdatePassenger(int pass_id, Update_PassengerDTO new_pass)
    {
        if (_dbContext.Passengers.Any(p =>
                p.FirstName == new_pass.FirstName &&
                p.LastName == new_pass.LastName &&
                p.Email == new_pass.Email))
        { //    check if there are duplicate passengers
            throw new BadRequestApiException("The passenger's information is already existed in database");
        }

        var pass = await _dbContext.Passengers.FindAsync(pass_id);

        if (pass == null)
        {
            throw new NotFoundApiException($"Passenger with ID {pass_id} doesn't exist");
        }
    
        _mapper.Map(new_pass, pass);

        await _dbContext.SaveChangesAsync();
    }
    public async Task DeletePassenger(int pass_id)
    {
        var pass = await _dbContext.Passengers.FindAsync(pass_id);

        if (pass == null)
        {
            throw new NotFoundApiException($"Passenger with ID {pass_id} doesn't exist");
        }

        _dbContext.Passengers.Remove(pass);
        
        await _dbContext.SaveChangesAsync();
    }
}