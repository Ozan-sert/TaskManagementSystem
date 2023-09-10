using System.Linq.Expressions;
using TaskManagementSystem.Core;
using TaskManagementSystem.Core.Models;
using TaskManagementSystem.Core.Services;

namespace TaskManagementSystem.Services;

public class QuoteService : IQuoteService
{
    private readonly IUnitOfWork _unitOfWork;

    public QuoteService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<IEnumerable<Quote>> GetAllQuotesAsync()
    {
        return await _unitOfWork.Quotes.GetAllAsync();
    }

    public async Task<Quote> GetQuoteByIdAsync(int id)
    {
        return await _unitOfWork.Quotes.GetByIdAsync(id);
    }

    public async Task<Quote> AddQuoteAsync(Quote quote)
    {
        await _unitOfWork.Quotes.AddAsync(quote);
        await _unitOfWork.CommitAsync();

        return quote;
    }
    

    public async Task UpdateQuoteAsync(int id, Quote quote)
    {
        var existingQuote = await _unitOfWork.Quotes.GetByIdAsync(id);

        if (existingQuote == null)
        {
            throw new InvalidOperationException("Quote not found");
        }

        existingQuote.QuoteType = quote.QuoteType;
        existingQuote.Description = quote.Description;
        existingQuote.DueDate = quote.DueDate;
        existingQuote.Premium = quote.Premium;
        existingQuote.Sales = quote.Sales;
        
        await _unitOfWork.Quotes.UpdateAsync(existingQuote);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteQuoteAsync(int id)
    {
        var existingQuote = await _unitOfWork.Quotes.GetByIdAsync(id);

        if (existingQuote == null)
        {
            throw new InvalidOperationException("Quote not found");
        }

        await _unitOfWork.Quotes.RemoveAsync(existingQuote);
        await _unitOfWork.CommitAsync();
    }
}