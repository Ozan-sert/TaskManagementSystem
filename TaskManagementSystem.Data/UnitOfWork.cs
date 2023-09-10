using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Core;
using TaskManagementSystem.Core.Repositories;
using TaskManagementSystem.Data.Repositories;

namespace TaskManagementSystem.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private IQuoteRepository _quoteRepository;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IQuoteRepository Quotes => _quoteRepository ??= new QuoteRepository(_context);
   
    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}