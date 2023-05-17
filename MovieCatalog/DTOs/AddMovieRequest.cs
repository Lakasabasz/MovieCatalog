namespace MovieCatalog.DTOs;

public class AddMovieRequest
{
    public string Name { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public int Year { get; set; }
    public string? Description { get; set; }
}