using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Core.Models;
using TaskManagementSystem.Core.Repositories;

namespace TaskManagementSystem.Data.Repositories;

public class QuoteRepository : Repository<Quote>, IQuoteRepository
{
    public QuoteRepository(DbContext context) : base(context)
    {
    }
   
}