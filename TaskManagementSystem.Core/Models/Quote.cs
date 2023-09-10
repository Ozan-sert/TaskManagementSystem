namespace TaskManagementSystem.Core.Models;

public enum QuoteType
{
    Auto,
    Boat,
    Home,
    General
}

public class Quote
{
    public int QuoteID { get; set; }
    public QuoteType QuoteType { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Premium { get; set; }
    public int Sales { get; set; }
}

