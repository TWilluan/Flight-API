

using API.Configuration.Exceptions;
using API.Controller;
using API.DTOs;
using API.Models;
using API.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

/***************************************************************
    PassengerController:
        The `PassengerController` is responsible for handling basic 
            operations related to flights in the airline system.
****************************************************************/

[ApiController]
[Route("[controller]")]
public class PassengerController : ApiController
{
    public IPassengerService _passService;
    public ILogger<PassengerController> _logger;

    public PassengerController(IPassengerService passService, ILogger<PassengerController> logger)
    {
        _passService = passService ?? throw new ArgumentNullException(nameof(passService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }


    // POST: ../passenger/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreatePassenger([FromBody] Create_PassengerDTO new_passenger)
    {
        _logger.LogInformation($"Calling: {nameof(CreatePassenger)}");

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var pass = await _passService.CreatePassenger(new_passenger);

        return Created(new Uri($"{Request.Path}passenger", UriKind.Relative), pass);
    }

    // GET: ../passenger/id
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Reponse_PassengerDTO>> GetPassenger(int id)
    {
        _logger.LogInformation($"Calling: {nameof(GetPassenger)}");
        
        var passenger = await _passService.GetPassenger(id);
        
        return Ok(passenger);
    }

    // GET: ../passenger
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status203NonAuthoritative)]
    public async Task<ActionResult<IEnumerable<Reponse_PassengerDetailDTO>>> GetAllPassengers()
    {
        _logger.LogInformation($"Calling: {nameof(GetAllPassengers)}");

        var passengers = await _passService.GetAllPassenger();

        return Ok(passengers);
    }

    // GET: ../passenger/id/allflight
    [HttpGet("{id:int}/allflight")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Reponse_FlightDTO>>> GetAllFlights_PassengerHas(int id)
    {
        _logger.LogInformation($"Calling: {nameof(GetAllFlights_PassengerHas)}");

        var flights = await _passService.GetAllFlights_PassengerHas(id);

        return Ok(flights); 
    }

    // POST: ../passenger/id
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdatePassenger(int id, Update_PassengerDTO pass)
    {
        _logger.LogInformation($"Calling: {nameof(UpdatePassenger)}");

        await _passService.UpdatePassenger(id, pass);

        return NoContent();
    }

    // DELETE: ../passenger/id
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePassenger(int id)
    {
        _logger.LogInformation($"Calling: {nameof(DeletePassenger)}");

        await _passService.DeletePassenger(id);

        return NoContent();
    }
}