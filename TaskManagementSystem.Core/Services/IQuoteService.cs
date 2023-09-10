using TaskManagementSystem.Core.Models;

namespace TaskManagementSystem.Core.Services;

public interface IQuoteService
{
    Task<IEnumerable<Quote>> GetAllQuotesAsync();
    Task<Quote> GetQuoteByIdAsync(int quoteId);
    Task<Quote> AddQuoteAsync(Quote quote);
    Task UpdateQuoteAsync(int id, Quote quote);
    Task DeleteQuoteAsync(int quoteId);

    // Define additional methods for Quote-related business logic if needed.
}