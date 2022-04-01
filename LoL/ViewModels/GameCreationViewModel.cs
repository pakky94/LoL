using LoL.Models;

namespace LoL.ViewModels;

public class GameCreationViewModel
{
    public Game Game { get; init; }
    public IEnumerable<Team> Teams { get; init; }
    public IEnumerable<Legend> Legends { get; init; }
}
