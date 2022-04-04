namespace LoL.Models;

public class Legend : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
}