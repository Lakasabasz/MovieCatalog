using MovieCatalog.DTOs;
using MovieCatalog.Models;

namespace MovieCatalog.Services;

public interface IMovieService
{
    Task AddMovie(AddMovieRequest amr);
    Task<Movie?> GetLastMovie();
    IEnumerable<Movie> GetMoviesByGenre(string genre);
    IEnumerable<Movie> GetMoviesByYear(int year);
}