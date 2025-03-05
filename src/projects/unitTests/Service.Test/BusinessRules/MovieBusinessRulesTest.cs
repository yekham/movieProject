using Core.CrossCuttingConcerns.Exceptions.Types;
using Moq;
using MovieProject.DataAccess.Repositories.Abstracts;
using MovieProject.Model.Entities;
using MovieProject.Service.BusinessRules.Movies;
using MovieProject.Service.Constants.Movies;
using System.Linq.Expressions;

namespace Service.Test.BusinessRules;

public class MovieBusinessRulesTest
{
    // MethodunAdi_Olay_BeklenenDavranis
    private MovieBusinessRules _movieBusinessRules;
    private Mock<IMovieRepository> _movieRepository;
    [SetUp]
    public void Setup()
    {
        _movieRepository = new Mock<IMovieRepository>();
        _movieBusinessRules = new MovieBusinessRules(_movieRepository.Object);

    }
    [Test]
    public async Task MovieNameMutBeUniqueAsync_WhenNameExists_ShouldThrowBusinessException()
    {
        // Arrange : Verilerin hazirlandigi yer
        string movieName = "X men";
        _movieRepository.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<Movie, bool>>>(),true,default)).ReturnsAsync(true);

        // Act & Assert : Test edilen methodun calistigi yer
        // Assert : Testin dogru olup olmadiginin kontrol edildigi yer
        var ex = Assert.ThrowsAsync<BusinessException>(() => _movieBusinessRules.MovieNameMutBeUniqueAsync(movieName));
        
        Assert.AreEqual(ex.Message, MovieMessages.MovieNameMustBeUniqueMessage);
    }
    [Test]
    public async Task MovieNameMutBeUniqueAsync_WhenDoesNottExists_ShouldNotThrowException()
    {
        // Arrange
        string movieName = "X men";
        _movieRepository.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<Movie, bool>>>(), true, default)).ReturnsAsync(false);
        // Act & Assert
        Assert.DoesNotThrowAsync(() => _movieBusinessRules.MovieNameMutBeUniqueAsync(movieName));
    }
}
