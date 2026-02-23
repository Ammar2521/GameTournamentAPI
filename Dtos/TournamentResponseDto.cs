namespace GameTournamentAPI.Dtos;

public class TournamentResponseDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int MaxPlayers { get; set; }

    public DateTime Date { get; set; }
}