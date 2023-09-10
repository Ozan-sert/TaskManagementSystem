
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Core.Models;
using TaskManagementSystem.Core.Models.Auth;
using TaskManagementSystem.Data.Configurations;

namespace TaskManagementSystem.Data;

public class AppDbContext : IdentityDbContext<User, Role, Guid>
{
    public DbSet<Quote> Quotes { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new QuoteConfiguration());
      
    }

}