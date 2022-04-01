using LoL.Models;

namespace LoL.ViewModel;

public class TeamCreationViewModel
{
    public Team Team { get; set; }
    public IEnumerable<Player> Players { get; set; }
}
