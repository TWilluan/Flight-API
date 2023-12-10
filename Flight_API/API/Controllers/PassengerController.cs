

using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PassengerController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreatePassenger([FromBody] FlightObject flight)
    {
        
        return Ok();
    }

    [HttpGet]
    public IActionResult GetPassenger()
    {
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdatePassenger()
    {
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeletePassenger()
    {
        return Ok();
    }
}