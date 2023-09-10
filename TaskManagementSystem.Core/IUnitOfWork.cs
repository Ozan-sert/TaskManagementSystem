using TaskManagementSystem.Core.Repositories;

namespace TaskManagementSystem.Core;

public interface IUnitOfWork : IDisposable
{
    IQuoteRepository Quotes { get; }
    Task<int> CommitAsync();
}