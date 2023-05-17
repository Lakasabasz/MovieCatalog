using Microsoft.EntityFrameworkCore;
using MovieCatalog.DTOs;
using MovieCatalog.Models;
using MovieCatalog.Services;
using NUnit.Framework;

namespace MovieCatalog.UnitTests;

[TestFixture, SingleThreaded]
public class MovieService
{
    private Services.MovieService _service = null!;
    private AppDbContext _db = null!;
    
    [SetUp]
    public void SetUp()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("mock");
        _db = new AppDbContext(optionsBuilder.Options);
        _service = new Services.MovieService(_db);
    }

    [Test, Order(1)]
    public async Task TestAddObjects()
    {
        await _service.AddMovie(new AddMovieRequest()
        {
            Name = "Test1", Genre = "Test", Year = 2001, Description = "ABC"
        });
        await _service.AddMovie(new AddMovieRequest()
        {
            Name = "Test2", Genre = "Test", Year = 2001
        });
        await _service.AddMovie(new AddMovieRequest()
        {
            Name = "Test3", Genre = "Test", Year = 2002
        });
        await _service.AddMovie(new AddMovieRequest()
        {
            Name = "TestA", Genre = "Unit", Year = 2000, Description = "ABC"
        });
        await _service.AddMovie(new AddMovieRequest()
        {
            Name = "TestB", Genre = "Testing", Year = 2000
        });
        
        Assert.That(_db.Movies.Count(), Is.EqualTo(5));
    }
    
    [Test, Order(2)]
    public async Task TestGetLast()
    {
        var movie = await _service.GetLastMovie();
        Assert.That(movie?.Name, Is.EqualTo("TestB"));
    }
    
    [Test, Order(2)]
    public void TestGetByGenre()
    {
        var movies = _service.GetMoviesByGenre("Test").ToArray();
        Assert.That(movies.Select(x => x.Genre), Is.All.EqualTo("Test"));
        Assert.That(movies.Count(), Is.EqualTo(3));
    }
    
    [Test, Order(2)]
    public void TestGetByYear()
    {
        var movies = _service.GetMoviesByYear(2000).ToArray();
        Assert.That(movies.Select(x => x.Year), Is.All.EqualTo(2000));
        Assert.That(movies.Count(), Is.EqualTo(2));
    }
    
}