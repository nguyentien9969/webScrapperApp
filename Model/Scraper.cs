// Models/Scraper.cs
public class Scraper
{
    public int ScraperId { get; set; }
    public string ScraperName { get; set; }
    public string SourceUrl { get; set; }
    public string Schedule { get; set; }
    public bool Status { get; set; }

    public ICollection<ScrapedData> ScrapedData { get; set; }
    public ICollection<Log> Logs { get; set; }
}