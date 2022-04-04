namespace LoL.Models;

public class Player : EntityBase
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Nickname { get; set; }
    public string Nationality { get; set; }
    public string Category { get; set; }
    public DateTime Birthday { get; set; }
}
