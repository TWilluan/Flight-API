

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PassengerController : ControllerBase
{
    [HttpPost]
    public IActionResult CreatePassenger()
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