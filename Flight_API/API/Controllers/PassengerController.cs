

// using API.DTOs;
// using API.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace API.Controllers;

// [ApiController]
// [Route("[controller]")] // : ../api/passenger
// public class PassengerController : ControllerBase
// {
//     [HttpPost]
//     [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//     [ProducesResponseType(StatusCodes.Status201Created)]
//     [ProducesResponseType(StatusCodes.Status400BadRequest)]
//     public async Task<IActionResult> CreatePassenger(
//                                         [FromBody] Create_PassengerDTO pass)
//     {
        
//         return Ok();
//     }

//     // GET: ../api/passenger/id
//     [HttpGet("{id:guid}")]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     [ProducesResponseType(StatusCodes.Status404NotFound)]
//     [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//     public async Task<ActionResult<Reponse_PassengerDTO>> GetPassenger(Guid id)
//     {
//         return Ok();
//     }

//     [HttpGet]
//     [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     [ProducesResponseType(StatusCodes.Status203NonAuthoritative)]
//     public async Task<ActionResult<IEnumerable<Reponse_PassengerDetailDTO>>> GetAllPassenger()
//     {
//         return Ok();
//     }

//     // POST: ../api/passenger/id
//     [HttpPut("{id:guid}")]
//     [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//     [ProducesResponseType(StatusCodes.Status400BadRequest)]
//     [ProducesResponseType(StatusCodes.Status404NotFound)]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     public async Task<IActionResult> UpdatePassenger(Guid id, Update_PassengerDTO pass)
//     {
//         return Ok();
//     }

//     // DELETE: ../api/passenger/id
//     [HttpDelete("{id:guid}")]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//     [ProducesResponseType(StatusCodes.Status404NotFound)]
//     public async Task<IActionResult> DeletePassenger(Guid id)
//     {
//         return Ok();
//     }
// }