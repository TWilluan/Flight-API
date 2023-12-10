

using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateFlight()
    {
        return Ok();
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