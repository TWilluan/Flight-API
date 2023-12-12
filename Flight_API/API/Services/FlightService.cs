
using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Service;

public class FlightService : IFlightService
{
    private readonly APIdbContext _dbContext;
    public FlightService(APIdbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateFlight(Create_FlightDTO flight)
    {
        var _flight = new FlightObject
        {
            Flight_No = flight.Flight_No,
            Capacity = flight.Capacity,
            Origin = flight.Origin,
            Destination = flight.Destination,
            Time_Ori = flight.Time_Ori,
            Time_Des = flight.Time_Des,
            Gate = flight.Gate,
            List_Passenger = new()
        };
        _dbContext.Flights.Add(_flight);
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateFlight(string flight_no, Update_FlightDTO flight_update)
    {
        var flight = await _dbContext.Flights.FirstOrDefaultAsync(f => f.Flight_No == flight_no);

        { //update flight information
            flight.Origin = flight_update.Origin;
            flight.Destination = flight_update.Destination;
            flight.Time_Ori = flight_update.Time_Ori;
            flight.Time_Des = flight_update.Time_Des;
            flight.Gate = flight_update.Gate;
        }
        await _dbContext.SaveChangesAsync();
    }
    public async Task<IEnumerable<Reponse_FlightDTO>> GetAllFlight()
    {
        var flights = await _dbContext.Flights.
                            Select(f => new Reponse_FlightDTO
                            {
                                Flight_No = f.Flight_No,
                                Origin = f.Origin,
                                Destination = f.Destination,
                                Time_Ori = f.Time_Ori,
                                Time_Des = f.Time_Des,
                                Gate = f.Gate
                            }).ToListAsync();
        
        return flights;
    }
    public async Task<Reponse_FlightDTO> GetFlight(string flight_no)
    {
        var flight = await _dbContext.Flights.
                    Where(f => f.Flight_No == flight_no).
                    Select(f => new Reponse_FlightDTO
                        {
                            Flight_No = f.Flight_No,
                            Origin = f.Origin,
                            Destination = f.Destination,
                            Time_Ori = f.Time_Ori,
                            Time_Des = f.Time_Des,
                            Gate = f.Gate
                        }).FirstAsync();

        // handlle not found exception
        return flight;
    }
    public async Task DeleteFlight(string flight_no)
    {
        var flight = await _dbContext.Flights.
                        FirstAsync(f => f.Flight_No == flight_no);

        _dbContext.Flights.Remove(flight);
        await _dbContext.SaveChangesAsync();
    }
}