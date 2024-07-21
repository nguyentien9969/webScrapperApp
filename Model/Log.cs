public class Log
{
    public int LogId { get; set; }
    public int ScraperId { get; set; }
    public Scraper Scraper { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
    public string LogLevel { get; set; }
    public string Message { get; set; }
}