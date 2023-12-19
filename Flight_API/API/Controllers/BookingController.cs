

using API.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using API.DTOs;

namespace API.Controller;

/***************************************************************
    BookingController:
        The `FlightContrller` is responsible for handling booking
            operations between passengers and flights in the airline system.
****************************************************************/

[ApiController]
[Route("[controller]")]
public class BookingController : ControllerBase
{
    public IBookingService _bookingService;
    public ILogger<BookingController> _logger;

    public BookingController(IBookingService mapService, ILogger<BookingController> logger)
    {
        _bookingService = mapService ?? throw new ArgumentNullException(nameof(mapService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    //  POST: ../booking/pass_id/flightno/seat
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Booking(int pass_id, string flightno, string? seat)
    {
        _logger.LogInformation($"Calling: {nameof(Booking)}");

        var booking = await _bookingService.Booking(pass_id, flightno, seat);

        return Created(new Uri($"{Request.Path}{booking.PassengerID}{booking.FlightNo}", UriKind.Relative), booking);
    }

    // GET: ../booking/pass_id/flightno
    [HttpGet("{pass_id:int}/{flightno}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Reponse_BookingDTO>> GetBooking(int pass_id, string flightno)
    {
        _logger.LogInformation($"Calling: {nameof(GetBooking)}");

        var booking = await _bookingService.GetBooking(pass_id, flightno);

        return Ok(booking);
    }

    // PUT: ../booking/pass_id/flightno/seat
    [HttpPut("{pass_id:int}/{flightno}/{seat}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ChangeSeat(int pass_id, string flightno, string seat)
    {
        _logger.LogInformation($"Calling: {nameof(ChangeSeat)}");

        await _bookingService.ChangeSeat(pass_id, flightno, seat);

        return Ok();
    }

    // DELETE: ../booking/pass_id/flightno/seat
    [HttpDelete("{pass_id:int}/{flightno}/{seat}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteBooking(int pass_id, string flightno)
    {
        _logger.LogInformation($"Calling: {nameof(ChangeSeat)}");

        await _bookingService.CancelBooking(pass_id, flightno);

        return Ok();
    }
}