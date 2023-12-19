

using API.Data;
using API.Models;
using API.DTOs;

namespace API.Service;

public class MappingService : IMappingService
{
    public APIdbContext _dbContext;
    public MappingService(APIdbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    public async Task<PassengerFlight_Mapping> Booking(int pass_id, string FlightNo, string? seat)
    {
        var passenger = await _dbContext.Passengers.FindAsync(pass_id);
        var flight = await _dbContext.Flights.FindAsync(FlightNo);

        if (passenger == null || flight == null) return null!;
        
        var book = new PassengerFlight_Mapping
        {
            PassengerID = pass_id,
            FlightNo = FlightNo,
            Passenger = passenger!,
            Flight = flight!,
            Seat = seat,
            BookingTime = DateTime.UtcNow
        };

        passenger.PassengerFlightMapper.Add(book);
        flight.PassengerFlightMapper.Add(book);

        _dbContext.PassengerFlightMappings.Add(book);
        await _dbContext.SaveChangesAsync();

        return book;
    }

    public async Task<PassengerFlight_Mapping> GetBooking(int pass_id, string FlightNo)
    {
        var book = await _dbContext.PassengerFlightMappings.FindAsync(pass_id, FlightNo);

        return (book == null) ? null! : book;
    }

    public async Task ChangeSeat(int pass_id, string FlightNo, string Seat)
    {
        var book = await _dbContext.PassengerFlightMappings.FindAsync(pass_id, FlightNo);

        if (book == null) return;

        book.Seat = Seat;
        await _dbContext.SaveChangesAsync();
    }
    public async Task CancelBooking(int pass_id, string FlightNo)
    {
        var book = await _dbContext.PassengerFlightMappings.FindAsync(pass_id, FlightNo);

        if (book == null) return;

        var passenger = await _dbContext.Passengers.FindAsync(pass_id);
        var flight = await _dbContext.Flights.FindAsync(FlightNo);

        if (passenger == null || flight == null) return;

        passenger.PassengerFlightMapper.Remove(book);
        flight.PassengerFlightMapper.Remove(book);
        _dbContext.PassengerFlightMappings.Remove(book);

        await _dbContext.SaveChangesAsync();
    }
}
