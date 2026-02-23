using Microsoft.AspNetCore.Mvc;
using GameTournamentAPI.Services;
using GameTournamentAPI.Dtos;
namespace GameTournamentAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TournamentsController : ControllerBase
{
    private readonly ITournamentService _service;

    public TournamentsController(ITournamentService service)
    {
        _service = service;
    }
    // GET: api/tournaments?search=...
    [HttpGet]
    public async Task<ActionResult<List<TournamentResponseDto>>> GetAll([FromQuery] string? search)
    {
        var result = await _service.GetAllAsync(search);
        return Ok(result);
    }

    // GET: api/tournaments/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TournamentResponseDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    // POST: api/tournaments
    [HttpPost]
    public async Task<ActionResult<TournamentResponseDto>> Create(TournamentCreateDto dto)
    {
        var created = await _service.CreateAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT: api/tournaments/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, TournamentUpdateDto dto)
    {
        var success = await _service.UpdateAsync(id, dto);

        if (!success)
            return NotFound();

        return NoContent();
    }

    // DELETE: api/tournaments/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);

        if (!success)
            return NotFound();

        return NoContent();
    }
}