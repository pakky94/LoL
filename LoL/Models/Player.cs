namespace LoL.Models;

public class Player : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Nickname { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
}
