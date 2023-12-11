

using API.Controller;
using API.Data;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using API.Contracts.Flights;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightController : ApiController
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateFlight([FromBody] CreateFlight_Request flight)
    {
        
    }

    [HttpGet]
    public IActionResult GetFlight()
    {
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateFlight()
    {
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteFlight()
    {
        return Ok();
    }
}