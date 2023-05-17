using Microsoft.EntityFrameworkCore;
using MovieCatalog.DTOs;
using MovieCatalog.Models;

namespace MovieCatalog.Services;

public class MovieService: IMovieService
{
    private AppDbContext _db;

    public MovieService(AppDbContext db)
    {
        _db = db;
    }

    public async Task AddMovie(AddMovieRequest amr)
    {
        await _db.Movies.AddAsync(Movie.FromDto(amr));
        await _db.SaveChangesAsync();
    }

    public Task<Movie?> GetLastMovie()
    {
        return _db.Movies.LastOrDefaultAsync();
    }

    public IEnumerable<Movie> GetMoviesByGenre(string genre)
    {
        return _db.Movies.Where(x => string.Equals(x.Genre, genre, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Movie> GetMoviesByYear(int year)
    {
        return _db.Movies.Where(x => x.Year == year);
    }
}