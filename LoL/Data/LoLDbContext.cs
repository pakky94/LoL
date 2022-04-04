using LoL.Models;
using Microsoft.EntityFrameworkCore;

namespace LoL.Data;

public class LoLDbContext : DbContext
{
    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<Legend> Legends { get; set; } = null!;
    public DbSet<Team> Teams { get; set; } = null!;
    public DbSet<Composition> Compositions { get; set; } = null!;
    public DbSet<Game> Games { get; set; } = null!;

    public LoLDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var player = modelBuilder.Entity<Player>();

        var team = modelBuilder.Entity<Team>();
        team.HasOne(m => m.Player1).WithOne().HasForeignKey<Team>(m => m.Player1Id).OnDelete(DeleteBehavior.NoAction);
        team.HasOne(m => m.Player2).WithOne().HasForeignKey<Team>(m => m.Player2Id).OnDelete(DeleteBehavior.NoAction);
        team.HasOne(m => m.Player3).WithOne().HasForeignKey<Team>(m => m.Player3Id).OnDelete(DeleteBehavior.NoAction);
        team.HasOne(m => m.Player4).WithOne().HasForeignKey<Team>(m => m.Player4Id).OnDelete(DeleteBehavior.NoAction);
        team.HasOne(m => m.Player5).WithOne().HasForeignKey<Team>(m => m.Player5Id).OnDelete(DeleteBehavior.NoAction);

        var composition = modelBuilder.Entity<Composition>();
        composition.HasOne(c => c.Team).WithMany().HasForeignKey(c => c.TeamId);
        composition.HasOne(c => c.Legend1).WithMany().HasForeignKey(c => c.Legend1Id).OnDelete(DeleteBehavior.NoAction);
        composition.HasOne(c => c.Legend2).WithMany().HasForeignKey(c => c.Legend2Id).OnDelete(DeleteBehavior.NoAction);
        composition.HasOne(c => c.Legend3).WithMany().HasForeignKey(c => c.Legend3Id).OnDelete(DeleteBehavior.NoAction);
        composition.HasOne(c => c.Legend4).WithMany().HasForeignKey(c => c.Legend4Id).OnDelete(DeleteBehavior.NoAction);
        composition.HasOne(c => c.Legend5).WithMany().HasForeignKey(c => c.Legend5Id).OnDelete(DeleteBehavior.NoAction);

        var game = modelBuilder.Entity<Game>();
        game.HasOne(g => g.Composition1).WithOne().HasForeignKey<Game>(g => g.Composition1Id).OnDelete(DeleteBehavior.NoAction);
        game.HasOne(g => g.Composition2).WithOne().HasForeignKey<Game>(g => g.Composition2Id).OnDelete(DeleteBehavior.NoAction);
    }
}