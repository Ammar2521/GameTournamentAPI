using System.Collections.Generic;
namespace GameTournamentAPI.Models;

public class Tournament
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int MaxPlayers { get; set; }

    public DateTime Date { get; set; }
    public ICollection<Game>? Games { get; set; }
}
