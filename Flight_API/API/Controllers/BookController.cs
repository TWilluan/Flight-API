

using API.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using API.DTOs;

namespace API.Controller;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    public IMappingService _mapService;
    public ILogger<BookController> _logger;

    public BookController(IMappingService mapService, ILogger<BookController> logger)
    {
        _mapService = mapService ?? throw new ArgumentNullException(nameof(mapService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Booking(int pass_id, string flightno, string? seat)
    {
        _logger.LogInformation($"Calling: {nameof(Booking)}");

        var book = await _mapService.Booking(pass_id, flightno, seat);
        
        return CreatedAtAction(
            actionName: nameof(GetBooking),
            routeValues: new {id = pass_id, flight = flightno},
            value: book
        ); 
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Reponse_BookingDTO>> GetBooking(int pass_id, string flightno)
    {
        _logger.LogInformation($"Calling: {nameof(GetBooking)}");

        var book = await _mapService.GetBooking(pass_id, flightno);
        
        var result = new Reponse_BookingDTO
        {
            PassengerID = book.PassengerID,
            FlightNo = book.FlightNo,
            Passenger = book.Passenger,
            Flight = book.Flight,
            Seat = book.Seat,
            BookingTime = book.BookingTime
        };

        return result;
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ChangeSeat(int pass_id, string flightno, string seat)
    {
        _logger.LogInformation($"Calling: {nameof(ChangeSeat)}");

        await _mapService.ChangeSeat(pass_id, flightno, seat);

        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteBooking(int pass_id, string flightno)
    {
        _logger.LogInformation($"Calling: {nameof(ChangeSeat)}");
        await _mapService.CancelBooking(pass_id, flightno);
        return Ok();
    }
}