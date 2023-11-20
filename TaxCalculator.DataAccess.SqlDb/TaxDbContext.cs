using Microsoft.EntityFrameworkCore;
using TaxCalculator.DataAccess.SqlDb.DbModels;
using TaxCalculator.DataAccess.SqlDb.EntityConfigurations;

namespace TaxCalculator.DataAccess.SqlDb;

public class TaxDbContext : DbContext
{
    public TaxDbContext()
    { }

    public TaxDbContext(DbContextOptions<TaxDbContext> options)
        : base(options)
    { }

    /// <summary>
    /// Method is needed for migrations
    /// </summary>
    /// <param name="options"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // TODO: move connection string to appsettings/environment/etc
        if (!options.IsConfigured)
        {
            options
                .UseSqlServer("Server=EPUADNIW02E9\\SQLEXPRESS;Database=TaxDb;User=TaxCalculatorApp;Password=R3d6yf431dn1;TrustServerCertificate=True;");
        }
    }

    public DbSet<TaxBand> TaxBands { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TaxBandEntityConfiguration());
        modelBuilder.Entity<TaxBand>()
            .HasData(new TaxBand
            {
                Id = 1,
                Name = "Tax Band A",
                LowRange = 0,
                HighRange = 5000,
                Range = 0,
                IsActive = true
            },
            new TaxBand
            {
                Id = 2,
                Name = "Tax Band B",
                LowRange = 5000,
                HighRange = 20000,
                Range = 20,
                IsActive = true
            },
            new TaxBand
            {
                Id = 3,
                Name = "Tax Band C",
                LowRange = 20000,
                HighRange = int.MaxValue,
                Range = 40,
                IsActive = true
            });
    }
}