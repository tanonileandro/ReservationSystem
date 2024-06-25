using Domain.Entities;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationsController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllReservations()
    {
        var reservations = await _reservationService.GetAllReservationsAsync();
        return Ok(reservations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReservationById(int id)
    {
        var reservation = await _reservationService.GetReservationByIdAsync(id);
        if (reservation == null)
        {
            return NotFound();
        }
        return Ok(reservation);
    }

    [HttpPost]
    public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdReservation = await _reservationService.CreateReservationAsync(reservation);
        return CreatedAtAction(nameof(GetReservationById), new { id = createdReservation.Id }, createdReservation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReservation(int id, [FromBody] Reservation reservation)
    {
        if (id != reservation.Id || !ModelState.IsValid)
        {
            return BadRequest();
        }

        await _reservationService.UpdateReservationAsync(reservation);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReservation(int id)
    {
        await _reservationService.DeleteReservationAsync(id);
        return NoContent();
    }
}
