using Figura.Speedway.Model.DAO;
using Microsoft.EntityFrameworkCore;

namespace Figura.Speedway.Model;

public partial class SpeedwayContext : DbContext
{
    private string? _connectionString;

    public SpeedwayContext()
    {
    }

    public SpeedwayContext(DbContextOptions<SpeedwayContext> options)
        : base(options)
    {
    }

    public SpeedwayContext(string? connectionString)
    {
        _connectionString = connectionString;
    }

    public virtual DbSet<Name> Names { get; set; }

    public virtual DbSet<Nationality> Nationalities { get; set; }

    public virtual DbSet<SpeedwayReferee> SpeedwayReferees { get; set; }

    public virtual DbSet<SpeedwayTeam> SpeedwayTeams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Polish_100_CI_AI_KS_WS_SC_UTF8");

        modelBuilder.Entity<Name>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Names__3214EC07D2940BB9");

            entity.Property(e => e.Name1)
                .HasMaxLength(30)
                .HasColumnName("Name");
        });

        modelBuilder.Entity<Nationality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__National__3214EC0764F3DF7D");

            entity.ToTable("Nationality");

            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<SpeedwayReferee>(entity =>
        {
            entity.HasKey(e => e.RefId).HasName("PK__Speedway__2D2A2CF1CA173BEA");

            entity.ToTable("Speedway_Referee");

            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Nationality).HasMaxLength(30);
            entity.Property(e => e.Surname).HasMaxLength(30);
        });

        modelBuilder.Entity<SpeedwayTeam>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Speedway__123AE799EC66D6E4");

            entity.ToTable("Speedway_Team");

            entity.Property(e => e.City).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
