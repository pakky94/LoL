using System.ComponentModel.DataAnnotations.Schema;

namespace LoL.Models;

public class Composition : EntityBase
{
    public int TeamId { get; set; }
    public Team Team { get; set; }
    public int Legend1Id { get; set; }
    public int Legend2Id { get; set; }
    public int Legend3Id { get; set; }
    public int Legend4Id { get; set; }
    public int Legend5Id { get; set; }
    public Legend Legend1 { get; set; }
    public Legend Legend2 { get; set; }
    public Legend Legend3 { get; set; }
    public Legend Legend4 { get; set; }
    public Legend Legend5 { get; set; }
}
