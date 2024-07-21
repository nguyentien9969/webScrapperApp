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
    }
}
