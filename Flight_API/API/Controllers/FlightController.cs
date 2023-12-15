

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

        return Ok();
    }

    // GET: ../api/flight/id
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Reponse_FlightDTO>> GetFlight(Guid id)
    {
        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Reponse_FlightDetailDTO>>> GetAllFlight()
    {
        return Ok();
    }

    // PUT: ../api/flight/id
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdatFlight(Guid id, Create_FlightDTO flight)
    {
        return Ok();
    }

    // DELETE : ../api/flight/id
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteFlight(Guid id)
    {
        return Ok();
    }
}