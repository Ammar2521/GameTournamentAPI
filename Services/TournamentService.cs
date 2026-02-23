using GameTournamentAPI.Data;
using GameTournamentAPI.Dtos;
using GameTournamentAPI.Models;
using GameTournamentAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentAPI.Services;

public class TournamentService : ITournamentService
{
    private readonly AppDbContext _context;

    public TournamentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TournamentResponseDto> CreateAsync(TournamentCreateDto dto)
    {
        var entity = new Tournament
        {
            Title = dto.Title,
            Description = dto.Description,
            MaxPlayers = dto.MaxPlayers,
            Date = dto.Date
        };

        _context.Tournaments.Add(entity);
        await _context.SaveChangesAsync();

        return new TournamentResponseDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            MaxPlayers = entity.MaxPlayers,
            Date = entity.Date
        };
    }

    public async Task<TournamentResponseDto?> GetByIdAsync(int id)
    {
        var entity = await _context.Tournaments
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);

        if (entity is null)
            return null;

        return new TournamentResponseDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            MaxPlayers = entity.MaxPlayers,
            Date = entity.Date
        };
    }
    public async Task<List<TournamentResponseDto>> GetAllAsync(string? search)
    {
        var query = _context.Tournaments.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(t => t.Title.Contains(search));

        return await query
            .Select(t => new TournamentResponseDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                MaxPlayers = t.MaxPlayers,
                Date = t.Date
            })
            .ToListAsync();
    }

    public async Task<bool> UpdateAsync(int id, TournamentUpdateDto dto)
    {
        var entity = await _context.Tournaments.FindAsync(id);

        if (entity is null)
            return false;

        entity.Title = dto.Title;
        entity.Description = dto.Description;
        entity.MaxPlayers = dto.MaxPlayers;
        entity.Date = dto.Date;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Tournaments.FindAsync(id);

        if (entity is null)
            return false;

        _context.Tournaments.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}