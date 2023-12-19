

using API.Data;
using API.Models;
using API.DTOs;
using AutoMapper;

namespace API.Service;

public class BookingService : IBookingService
{
    private readonly APIdbContext _dbContext;
    private readonly IMapper _mapper;
    public BookingService(APIdbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<Reponse_BookingDTO> Booking(int pass_id, string FlightNo, string? seat)
    {
        var passenger = await _dbContext.Passengers.FindAsync(pass_id);
        var flight = await _dbContext.Flights.FindAsync(FlightNo);

        if (passenger == null || flight == null) return null!;
        
        var book = new PassengerFlight_Booking
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

        var res = _mapper.Map<Reponse_BookingDTO>(book);

        return res;
    }

    public async Task<Reponse_BookingDTO> GetBooking(int pass_id, string FlightNo)
    {
        var book = await _dbContext.PassengerFlightMappings.FindAsync(pass_id, FlightNo);

        var res = _mapper.Map<Reponse_BookingDTO>(book);

        return (res == null) ? null! : res;
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
