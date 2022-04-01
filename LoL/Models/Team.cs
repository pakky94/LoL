namespace LoL.Models;

public class Team : EntityBase
{
    public string Name { get; set; }
    public int Player1Id { get; set; }
    public int Player2Id { get; set; }
    public int Player3Id { get; set; }
    public int Player4Id { get; set; }
    public int Player5Id { get; set; }
    public Player? Player1 { get; set; }
    public Player? Player2 { get; set; }
    public Player? Player3 { get; set; }
    public Player? Player4 { get; set; }
    public Player? Player5 { get; set; }
}
