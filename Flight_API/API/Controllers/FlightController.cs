

using API.Controller;
using API.Data;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using API.Service;

namespace API.Controllers;

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


    // POST: ../api/flight/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateFlight([FromBody] Create_FlightDTO flight)
    {
        _logger.LogInformation($"Calling: {nameof(CreateFlight)}");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Call service to add flight to database
        await _flightService.CreateFlight(flight);
        return Created(
            new Uri($"{Request.Path}/{flight.FlightNo}", UriKind.Relative), 
            flight);
    }

    // GET: ../api/flight/flightno
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

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Reponse_FlightDetailDTO>>> GetAllFlight()
    {
        _logger.LogInformation($"Calling: {nameof(GetAllFlight)}");

        var flights = await _flightService.GetAllFlight();
        return Ok(flights);
    }

    // PUT: ../api/flight/flightno
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

    // DELETE : ../api/flight/flightno
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