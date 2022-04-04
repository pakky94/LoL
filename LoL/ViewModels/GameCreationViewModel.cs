using LoL.Models;

namespace LoL.ViewModels;

public class GameCreationViewModel
{
    public Game Game { get; init; } = new Game();
    public IEnumerable<Team> Teams { get; init; } = Enumerable.Empty<Team>();
    public IEnumerable<Legend> Legends { get; init; } = Enumerable.Empty<Legend>();
}
