using GameTournamentAPI.Dtos;

namespace GameTournamentAPI.Services;

public interface IGameService
{
    Task<List<GameResponseDto>> GetAllAsync();
    Task<GameResponseDto?> GetByIdAsync(int id);
    Task<GameResponseDto> CreateAsync(GameCreateDto dto);
    Task<bool> UpdateAsync(int id, GameUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}