using System.ComponentModel.DataAnnotations;

namespace GameTournamentAPI.Dtos;

public class TournamentCreateDto
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Range(1, int.MaxValue)]
    public int MaxPlayers { get; set; }

    [FutureDate]
    public DateTime Date { get; set; }
}
