using Microsoft.EntityFrameworkCore;
using Todododododododo.Models.Entities;

namespace Todododododododo.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    public DbSet<Users> Users { get; set; }
    public DbSet<Todos> Todos { get; set; }
}