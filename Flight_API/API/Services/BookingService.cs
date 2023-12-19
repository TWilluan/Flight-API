

using API.Data;
using API.Models;
using API.DTOs;
using AutoMapper;
using API.Configuration.Exceptions;

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
        
        if (passenger == null)
        {
            throw new NotFoundApiException($"Passenger with ID {pass_id} does not exist");
        }
        
        var flight = await _dbContext.Flights.FindAsync(FlightNo);

        if (flight == null)
        {
            throw new NotFoundApiException($"Flight {FlightNo} does not exist");
        }

        if (flight.Current_Pass == flight.Capacity)
        {
            throw new ForbiddenApiException("The flight is full at the moment");
        }
        
        var book = new PassengerFlight_Booking
        {
            PassengerID = pass_id,
            FlightNo = FlightNo,
            Passenger = passenger,
            Flight = flight,
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
        var booking = await _dbContext.PassengerFlightMappings.FindAsync(pass_id, FlightNo);

        if (booking == null)
        {
            throw new NotFoundApiException($"Booking of Passenger {pass_id} to Flight" 
                                                + " {FlightNo} doesn't exist");
        }

        return _mapper.Map<Reponse_BookingDTO>(booking);
    }

    public async Task ChangeSeat(int pass_id, string FlightNo, string Seat)
    {
        var booking = await _dbContext.PassengerFlightMappings.FindAsync(pass_id, FlightNo);

        if (booking == null)
        {
            throw new NotFoundApiException($"Booking of Passenger {pass_id} to Flight"
                                                + " {FlightNo} doesn't exist");
        }

        booking.Seat = Seat;

        await _dbContext.SaveChangesAsync();
    }

    public async Task CancelBooking(int pass_id, string FlightNo)
    {
        var booking = await _dbContext.PassengerFlightMappings.FindAsync(pass_id, FlightNo);

        if (booking == null) return;

        var passenger = await _dbContext.Passengers.FindAsync(pass_id);
        var flight = await _dbContext.Flights.FindAsync(FlightNo);

        if (passenger == null || flight == null) return;

        passenger.PassengerFlightMapper.Remove(booking);
        flight.PassengerFlightMapper.Remove(booking);
        _dbContext.PassengerFlightMappings.Remove(booking);

        await _dbContext.SaveChangesAsync();
    }
}
