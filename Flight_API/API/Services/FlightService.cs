
using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Service;

public class FlightService : IFlightService
{

    public APIdbContext _dbContext;
    public FlightService(APIdbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }


    public async Task CreateFlight(Create_FlightDTO new_flight)
    {
        var flight = To_FlightObject(new_flight);

        // add flightobject to database
        _dbContext.Flights.Add(flight);
        await _dbContext.SaveChangesAsync(); 

    }
    public async Task<Reponse_FlightDTO> GetFlight(string FlightNo)
    {
        var flight = await _dbContext.Flights.FindAsync(FlightNo);

        if (flight == null) return null!;

        var result = new Reponse_FlightDTO
        {
            FlightNo = flight.FlightNo,
            Origin = flight.Origin,
            Destination = flight.Destination,
            Time_Ori = flight.Time_Ori,
            Time_Des = flight.Time_Des,
            Gate = flight.Gate
        };

        return result;                       
    }
    public async Task<IEnumerable<Reponse_FlightDetailDTO>> GetAllFlight()
    {
        var flights = await _dbContext.Flights.ToListAsync();

        if (flights == null) return null!;

        var results = flights.Select(f => new Reponse_FlightDetailDTO{
            FlightNo = f.FlightNo,
            Origin = f.Origin,
            Destination = f.Destination,
            Time_Ori = f.Time_Ori,
            Time_Des = f.Time_Des,
            Gate = f.Gate
        }).ToList();
        return results;
    }

    public async Task UpdateFlight(string FlightNo, Update_FlightDTO new_flight)
    {
        var flight = await _dbContext.Flights.FindAsync(FlightNo);

        if (flight == null) return;
        // update flightobject in database
        {
            flight.Capacity = new_flight.Capacity;
            flight.Origin = new_flight.Origin;
            flight.Destination = new_flight.Destination;
            flight.Time_Ori = new_flight.Time_Ori;
            flight.Time_Des = new_flight.Time_Des;
            flight.Gate = new_flight.Gate;
        }
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteFlight(string FlightNo)
    {
        var flight = await _dbContext.Flights.FindAsync(FlightNo);

        if (flight == null) return;

        _dbContext.Flights.Remove(flight);
        await _dbContext.SaveChangesAsync();
    }

   
    /*********************************************************
            Private support function
    **********************************************************/
    private FlightObject To_FlightObject(Create_FlightDTO new_flight)
    {
        return new FlightObject
        {
            FlightNo = new_flight.FlightNo,
            Capacity = new_flight.Capacity,
            Current_Pass = 0,
            Origin = new_flight.Origin,
            Destination = new_flight.Destination,
            Time_Ori = new_flight.Time_Ori,
            Time_Des = new_flight.Time_Des,
            Gate = new_flight.Gate
        };
    }
}