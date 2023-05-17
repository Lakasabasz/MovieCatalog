using Microsoft.EntityFrameworkCore;
using MovieCatalog.Models;

namespace MovieCatalog.Services;

public class AppDbContext: DbContext
{
    public DbSet<Movie> Movies { get; private set; } = null!;

    public AppDbContext(DbContextOptions options): base(options)
    {
        
    }
}