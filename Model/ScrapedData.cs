 // Models/ScrapedData.cs
public class ScrapedData
{
    public int DataId { get; set; }
    public int ScraperId { get; set; }
    public Scraper Scraper { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
    public string RawData { get; set; }
    public string ParsedData { get; set; }
}