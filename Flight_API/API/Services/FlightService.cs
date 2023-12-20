
using API.Configuration.Exceptions;
using API.Data;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace API.Service;

public class FlightService : IFlightService
{
    private readonly APIdbContext _dbContext;
    private readonly IMapper _mapper;
    public FlightService(APIdbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Reponse_FlightDTO> CreateFlight(Create_FlightDTO new_flight)
    {
        var flight = _mapper.Map<FlightObject>(new_flight);

        _dbContext.Flights.Add(flight);

        await _dbContext.SaveChangesAsync(); 

        var response = _mapper.Map<Reponse_FlightDTO>(flight);
        return response;
    }

    public async Task<Reponse_FlightDTO> GetFlight(string FlightNo)
    {
        var flight = await _dbContext.Flights.FindAsync(FlightNo);

        if (flight == null)
        {
            throw new NotFoundApiException($"Flight {FlightNo} is not in database");
        }

        var result = _mapper.Map<Reponse_FlightDTO>(flight);

        return result;                       
    }
    public async Task<IEnumerable<Reponse_FlightDetailDTO>> GetAllFlight()
    {
        var flights = await _dbContext.Flights.ToListAsync();

        if (flights == null) return null!;

        if (flights == null)
        {
            throw new NotFoundApiException($"There is no flight in database");
        }

        var results = flights.Select(f =>
                            _mapper.Map<Reponse_FlightDetailDTO>(f))
                            .ToList();

        return results;
    }

    public async Task<IEnumerable<Reponse_PassengerDTO>> GetAllPassenger_InFlight(string FlightNo)
    {
        var flight = await _dbContext.Flights
            .Include(f => f.PassengerFlightMapper)  // Ensure Bookings are loaded
            .ThenInclude(b => b.Passenger)  // Ensure Passenger is loaded within each Booking
            .FirstOrDefaultAsync(f => f.FlightNo == FlightNo);

        if (flight == null)
        {
            throw new NotFoundApiException($"Flight {FlightNo} is not in the database");
        }

        var passengers = flight.PassengerFlightMapper
            .Select(b => b.Passenger)
            .Select(p => _mapper.Map<Reponse_PassengerDTO>(p))
            .ToList();

        return passengers;
    }

    public async Task UpdateFlight(string FlightNo, Update_FlightDTO new_flight)
    {
        var flight = await _dbContext.Flights.FindAsync(FlightNo);

        if (flight == null)
        {
            throw new NotFoundApiException($"Flight {FlightNo} is not in database");
        }

        _mapper.Map(new_flight, flight); // update existing flight with new flight
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteFlight(string FlightNo)
    {
        var flight = await _dbContext.Flights.FindAsync(FlightNo);

        if (flight == null)
        {
            throw new NotFoundApiException($"Flight {FlightNo} is not in database");
        }

        _dbContext.Flights.Remove(flight);

        await _dbContext.SaveChangesAsync();
    }
}