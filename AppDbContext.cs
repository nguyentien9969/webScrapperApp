// Data/WebScraperContext.cs
using Microsoft.EntityFrameworkCore;

public class WebScraperContext : DbContext
{
    public WebScraperContext(DbContextOptions<WebScraperContext> options) : base(options)
    {
    }

    public DbSet<Scraper> Scrapers { get; set; }
    public DbSet<ScrapedData> ScrapedData { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Log> Logs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Scraper>()
            .HasMany(s => s.ScrapedData)
            .WithOne(d => d.Scraper)
            .HasForeignKey(d => d.ScraperId);

        modelBuilder.Entity<Scraper>()
            .HasMany(s => s.Logs)
            .WithOne(l => l.Scraper)
            .HasForeignKey(l => l.ScraperId);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Scraper>().HasData(
    new Scraper { ScraperId = 1, ScraperName = "Example Scraper 1", SourceUrl = "http://example.com", Schedule = "Daily", Status = true },
    new Scraper { ScraperId = 2, ScraperName = "Example Scraper 2", SourceUrl = "http://example2.com", Schedule = "Weekly", Status = false}
);

        // Seed data for Users
        modelBuilder.Entity<User>().HasData(
            new User { UserId = 1, Username = "admin", Email = "admin@example.com", Password = "password123", Role = "Administrator" },
            new User { UserId = 2, Username = "user", Email = "user@example.com", Password = "password123", Role = "User" }
        );

        // Seed data for Logs
        modelBuilder.Entity<Log>().HasData(
            new Log { LogId = 1, ScraperId = 1, Timestamp = DateTime.UtcNow, LogLevel = "Info", Message = "Scraper started"},
            new Log { LogId = 2, ScraperId = 2, Timestamp = DateTime.UtcNow, LogLevel = "Warning", Message = "Scraper encountered an issue" }
        );

        // Seed data for ScrapedData
        modelBuilder.Entity<ScrapedData>().HasData(
            new ScrapedData { ScrapedDataId = 1, ScraperId = 1, Timestamp = DateTime.UtcNow, RawData = "Raw data 1", ParsedData = "Parsed data 1" },
            new ScrapedData { ScrapedDataId = 2, ScraperId = 2, Timestamp = DateTime.UtcNow, RawData = "Raw data 2", ParsedData = "Parsed data 2" }
        );

    }
}
