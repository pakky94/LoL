﻿namespace LoL.Models;

public class Legend : EntityBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Bio { get; set; }
}