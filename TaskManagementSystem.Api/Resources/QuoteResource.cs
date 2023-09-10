using TaskManagementSystem.Core.Models;

namespace TaskManagementSystem.Api.Resources;

public class QuoteResource
{
    public int QuoteID { get; set; }
    public string QuoteType { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Premium { get; set; }
    public int Sales { get; set; }
}