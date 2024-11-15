using eTicaret.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eTicaret.Infrastructure.Context;
public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; } = default!;
}
