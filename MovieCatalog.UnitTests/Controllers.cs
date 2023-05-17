using Moq;
using MovieCatalog.Controllers;
using MovieCatalog.DTOs;
using MovieCatalog.Models;
using MovieCatalog.Services;

namespace MovieCatalog.UnitTests;

[TestFixture]
public class CatalogControllerTest
{
    private CatalogController _controller = null!;
    
    [SetUp]
    public void Setup()
    {
        var mock = new Mock<IMovieService>();
        mock.Setup(x => x.GetLastMovie()).ReturnsAsync(new Movie());
        mock.Setup(x => x.GetMoviesByGenre("test")).Returns(new[] { new Movie(), new Movie() });
        mock.Setup(x => x.GetMoviesByYear(2007)).Returns(new[] { new Movie(), new Movie(), new Movie() });
        _controller = new CatalogController(mock.Object);
    }

    [Test]
    public async Task TestGetLast()
    {
        var movie = await _controller.GetLast();
        Assert.IsNotNull(movie);
    }

    [Test]
    public void TestGetByGenres()
    {
        var movies = _controller.GetByGenre("test");
        Assert.That(movies.Count() == 2);
    }

    [Test]
    public void TestGetByYear()
    {
        var movies = _controller.GetByYear(2007);
        Assert.That(movies.Count() == 3);
    }

    [Test]
    public void TestAddMovie()
    {
        _controller.AddMovie(new AddMovieRequest()
        {
            Genre = "",
            Name = "",
            Year = 2007
        });
        Assert.Pass();
    }
}