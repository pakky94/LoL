namespace LoL.Models;

public class Game : EntityBase
{
    public int Composition1Id { get; set; }
    public int Composition2Id { get; set; }
    public Composition Composition1 { get; set; }
    public Composition Composition2 { get; set; }
    public int Winner { get; set; }
    public DateTime GameDate { get; set; }
}
