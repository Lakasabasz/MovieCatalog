using MovieCatalog.DTOs;

namespace MovieCatalog.Models;

public class Movie
{
    public Guid MovieId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public int Year { get; set; }
    public string? Description { get; set; }

    public static Movie FromDto(AddMovieRequest amr)
    {
        return new Movie()
        {
            MovieId = Guid.NewGuid(),
            Name = amr.Name,
            Genre = amr.Genre,
            Year = amr.Year,
            Description = amr.Description
        };
    }
}