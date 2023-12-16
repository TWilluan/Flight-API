

using API.DTOs;
using API.Models;
using API.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")] // : ../api/passenger
public class PassengerController : ControllerBase
{
    public IPassengerService _passService;
    public ILogger<PassengerController> _logger;

    public PassengerController(IPassengerService passService, ILogger<PassengerController> logger)
    {
        _passService = passService ?? throw new ArgumentNullException(nameof(passService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }


    // POST: ../api/passenger/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreatePassenger([FromBody] Create_PassengerDTO pass)
    {
        _logger.LogInformation($"Calling: {nameof(CreatePassenger)}");

        if (!ModelState.IsValid)
            return BadRequest();

        await _passService.CreatePassenger(pass);

        return CreatedAtAction(
            actionName: nameof(CreatePassenger),
            value: pass
        );
    }

    // GET: ../api/passenger/id
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Reponse_PassengerDTO>> GetPassenger(int id)
    {
        _logger.LogInformation($"Calling: {nameof(GetPassenger)}");
        
        var flight = await _passService.GetPassenger(id);

        if (flight == null)
            return NotFound();
        
        return Ok(flight);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status203NonAuthoritative)]
    public async Task<ActionResult<IEnumerable<Reponse_PassengerDetailDTO>>> GetAllPassenger()
    {
        _logger.LogInformation($"Calling: {nameof(GetAllPassenger)}");

        var flights = await _passService.GetAllPassenger();

        if (flights == null)
            return NotFound();

        return Ok(flights);
    }

    // POST: ../api/passenger/id
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdatePassenger(int id, Update_PassengerDTO pass)
    {
        _logger.LogInformation($"Calling: {nameof(UpdatePassenger)}");

        await _passService.UpdatePassenger(id, pass);
        return Ok();
    }

    // DELETE: ../api/passenger/id
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePassenger(int id)
    {
        _logger.LogInformation($"Calling: {nameof(DeletePassenger)}");

        await _passService.DeletePassenger(id);
        return Ok();
    }
}