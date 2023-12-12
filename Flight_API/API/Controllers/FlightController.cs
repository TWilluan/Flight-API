

using API.Controller;
using API.Data;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using API.Contracts.Flights;
using API.Service;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightController : ApiController
{
    private readonly IFlightService _service;

    public FlightController(IFlightService flight_serivce) => _service = flight_serivce;

    //  POST: api/flight
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateFlight([FromBody] CreateFlight_Request flight)
    {
        var flight_dto = parse_CreateRequest(flight);

        //Add to flight to datbase
        await _service.CreateFlight(flight_dto);

        return CreatedAtAction(
            actionName: (nameof(CreateFlight)),
            routeValues: new {flight_no = flight_dto.Flight_No},
            value: flight_dto);
    }

    [HttpGet("{flight_no:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Flight_Reponse>> GetFlight(string flight_no)
    {
        var flight = await _service.GetFlight(flight_no);
        
        //Convert to response
        Flight_Reponse result = to_Reponse(flight);
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Flight_Reponse>>> GetAllFlight()
    {
        var flights = await _service.GetAllFlight();
        
        //convert to reponse contracts
        IEnumerable<Flight_Reponse> results = flights.Select(
                                            f => new Flight_Reponse{
                                                Flight_No = f.Flight_No,
                                                Origin = f.Origin,
                                                Destination = f.Destination,
                                                Time_Ori = f.Time_Ori,
                                                Time_Des = f.Time_Des,
                                                Gate = f.Gate
                                            });
        return Ok(results);
    }

    [HttpPut("{flight_no:guid}")]
    public async Task<IActionResult> UpdateFlight(string flight_no, UpdateFlight_Request flight)
    {
        var flight_dto = new Update_FlightDTO{
            Flight_No = flight.Flight_no,
            Origin = flight.Origin,
            Destination = flight.Destination,
            Time_Ori = flight.Time_Ori,
            Time_Des = flight.Time_Des,
            Gate = flight.Gate
        };

        await _service.UpdateFlight(flight_no, flight_dto);
        return Ok();
    }

    [HttpDelete("{flight_no:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteFlight(string flight_no)
    {
            await _service.DeleteFlight(flight_no);
            return NoContent(); // 204 No Content
    }

    /*
            private function
    */
    private Create_FlightDTO parse_CreateRequest(CreateFlight_Request flight)
    {
        var result = new Create_FlightDTO
        {
            Flight_No = flight.Flight_no,
            Capacity = flight.Capacity,
            Origin = flight.Origin,
            Destination = flight.Destination,
            Time_Ori = flight.Time_Ori,
            Time_Des = flight.Time_Des,
            Gate = flight.Gate
        };
        return result;
    }

    private Flight_Reponse to_Reponse(Reponse_FlightDTO flight)
    {
        var result = new Flight_Reponse
        {
            Flight_No = flight.Flight_No,
            Origin = flight.Origin,
            Destination = flight.Destination,
            Time_Ori = flight.Time_Ori,
            Time_Des = flight.Time_Des,
            Gate = flight.Gate,
            LastModifiedDate = DateTime.UtcNow
        };

        return result;
    } 
}