using System.ComponentModel.DataAnnotations;

namespace GameTournamentAPI.Dtos;

public class GameUpdateDto
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public DateTime Time { get; set; }

    [Required]
    public int TournamentId { get; set; }
}