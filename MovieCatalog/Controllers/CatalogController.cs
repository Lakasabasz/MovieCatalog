using System.Net;
using Microsoft.AspNetCore.Mvc;
using MovieCatalog.DTOs;
using MovieCatalog.Models;
using MovieCatalog.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace MovieCatalog.Controllers;

[ApiController, Route("/")]
public class CatalogController : Controller
{
    private IMovieService _movieService;

    public CatalogController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpPost("/")]
    public void AddMovie(AddMovieRequest amr)
    {
        _movieService.AddMovie(amr);
    }

    [HttpGet("/")]
    [SwaggerResponse((int)HttpStatusCode.NoContent, Description = "Database is empty")]
    [SwaggerResponse((int)HttpStatusCode.OK, Description = "Success")]
    public async Task<Movie?> GetLast()
    {
        return await _movieService.GetLastMovie();
    }

    [HttpGet("/year/{year}")]
    public IEnumerable<Movie> GetByYear(int year)
    {
        return _movieService.GetMoviesByYear(year);
    }

    [HttpGet("/genre/{genre}")]
    public IEnumerable<Movie> GetByGenre(string genre)
    {
        return _movieService.GetMoviesByGenre(genre);
    }
}