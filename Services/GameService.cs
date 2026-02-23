using Microsoft.EntityFrameworkCore;
using GameTournamentAPI.Data;
using GameTournamentAPI.Dtos;
using GameTournamentAPI.Models;

namespace GameTournamentAPI.Services;

public class GameService : IGameService
{
    private readonly AppDbContext _context;

    public GameService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<GameResponseDto>> GetAllAsync()
    {
        var games = await _context.Games.ToListAsync();

        return games.Select(g => new GameResponseDto
        {
            Id = g.Id,
            Title = g.Title,
            Time = g.Time,
            TournamentId = g.TournamentId
        }).ToList();
    }

    public async Task<GameResponseDto?> GetByIdAsync(int id)
    {
        var g = await _context.Games.FindAsync(id);
        if (g == null) return null;

        return new GameResponseDto
        {
            Id = g.Id,
            Title = g.Title,
            Time = g.Time,
            TournamentId = g.TournamentId
        };
    }

    public async Task<GameResponseDto> CreateAsync(GameCreateDto dto)
    {
        // Extra-säkerhet: kolla att tournament finns
        var tournamentExists = await _context.Tournaments.AnyAsync(t => t.Id == dto.TournamentId);
        if (!tournamentExists)
            throw new ArgumentException("TournamentId does not exist");

        var game = new Game
        {
            Title = dto.Title,
            Time = dto.Time,
            TournamentId = dto.TournamentId
        };

        _context.Games.Add(game);
        await _context.SaveChangesAsync();

        return new GameResponseDto
        {
            Id = game.Id,
            Title = game.Title,
            Time = game.Time,
            TournamentId = game.TournamentId
        };
    }

    public async Task<bool> UpdateAsync(int id, GameUpdateDto dto)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null) return false;

        var tournamentExists = await _context.Tournaments.AnyAsync(t => t.Id == dto.TournamentId);
        if (!tournamentExists)
            return false;

        game.Title = dto.Title;
        game.Time = dto.Time;
        game.TournamentId = dto.TournamentId;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null) return false;

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
        return true;
    }
}