

using API.Controller;
using API.Data;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using API.Service;
using API.Configuration.Exceptions;
using Microsoft.AspNetCore.Components.Routing;

namespace API.Controllers;

/***************************************************************
    FlightController:
        The `FlightContrller` is responsible for handling basic 
            operations related to flights in the airline system.
****************************************************************/

[ApiController]
[Route("[controller]")]
public class FlightController : ApiController
{
    private ILogger<FlightController> _logger;
    private IFlightService _flightService;

    public FlightController(ILogger<FlightController> logger, IFlightService flightService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _flightService = flightService ?? throw new ArgumentNullException(nameof(flightService));
    }

    // POST: ../flight/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateFlight([FromBody] Create_FlightDTO flight)
    {
        _logger.LogInformation($"Calling: {nameof(CreateFlight)}");

        await _flightService.CreateFlight(flight);

        return CreatedAtAction(
            actionName: nameof(GetFlight),
            routeValues: new {id = flight.FlightNo},
            value: flight
        );
    }

    // GET: ../flight/flightno
    [HttpGet("{FlightNo}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Reponse_FlightDTO>> GetFlight(string FlightNo)
    {
        _logger.LogInformation($"Calling: {nameof(GetFlight)}");

        var flight = await _flightService.GetFlight(FlightNo);
        return Ok(flight);
    }

    // GET: ../flight
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Reponse_FlightDetailDTO>>> GetAllFlights()
    {
        _logger.LogInformation($"Calling: {nameof(GetAllFlights)}");

        var flights = await _flightService.GetAllFlight();

        return Ok(flights);
    }

    // GET: ../flight/flightno
    [HttpGet("{flightno}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Reponse_PassengerDTO>>> GetAllPassenger_InFlight(string FlightNo)
    {
        return Ok();
    }

    // PUT: ../flight/flightno
    [HttpPut("{FlightNo}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateFlight(string FlightNo, Update_FlightDTO flight)
    {
        _logger.LogInformation($"Calling: {nameof(UpdateFlight)}");

        await _flightService.UpdateFlight(FlightNo, flight);

        return Ok();
    }

    // DELETE : ../flight/flightno
    [HttpDelete("{FlightNo}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteFlight(string FlightNo)
    {
        _logger.LogInformation($"Calling: {nameof(DeleteFlight)}");

        await _flightService.DeleteFlight(FlightNo);

        return Ok();
    }
}