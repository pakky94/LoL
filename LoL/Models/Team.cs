using System.ComponentModel.DataAnnotations;

namespace LoL.Models;

public class Team : EntityBase, IValidatableObject
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

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var ids = new HashSet<int> { Player1Id, Player2Id, Player3Id, Player4Id, Player5Id };
        if (ids.Count < 5)
        {
            yield return new ValidationResult(
                $"All 5 player must be different",
                new[] { nameof(Player1Id) });
        }
    }
}
