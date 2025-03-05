using AutoMapper;
using Moq;
using MovieProject.DataAccess.Repositories.Abstracts;
using MovieProject.Service.BusinessRules.Directors;
using MovieProject.Service.Concretes;
using MovieProject.Service.Helpers;

namespace Service.Test.Services;

public class DirectorServiceTests
{
    private DirectorService _directorService;
    private Mock<IMapper> _mapperMock;
    private Mock<IDirectorRepository> _directorRepository;
    private Mock<ICloudinaryHelper> _cloudinaryHelper;
    private Mock<DirectorBusinessRules> _directorBusinessRules;
    [SetUp]
    public void Setup()
    {
        _mapperMock = new Mock<IMapper>();
        _directorRepository = new Mock<IDirectorRepository>();
        _cloudinaryHelper = new Mock<ICloudinaryHelper>();
        _directorBusinessRules = new Mock<DirectorBusinessRules>();
        _directorService = new DirectorService(_mapperMock.Object, _directorRepository.Object, _cloudinaryHelper.Object, _directorBusinessRules.Object);
    }
    [Test]
    public async Task AddAsync_WhenDirectorNameExists_ShouldThrowBusinessException()
    {
        // Arrange
        var dto = new DirectorAddRequestDto
        {
            Name = "James",
            Surname = "Cameron"
        };
        _directorBusinessRules.Setup(x => x.DirectorNameMustBeUnique(dto.Name, dto.Surname)).ThrowsAsync(new BusinessException("Director name must be unique"));
        // Act & Assert
        var ex = Assert.ThrowsAsync<BusinessException>(() => _directorService.AddAsync(dto));
        Assert.AreEqual(ex.Message, "Director name must be unique");
    }
    [Test]
    public async Task AddAsync_WhenDirectorNameDoesNotExists_ShouldNotThrowException()
    {
        // Arrange
        var dto = new DirectorAddRequestDto
        {
            Name = "James",
            Surname = "Cameron"
        };
        _directorBusinessRules.Setup(x => x.DirectorNameMustBeUnique(dto.Name, dto.Surname));
        // Act & Assert
        Assert.DoesNotThrowAsync(() => _directorService.AddAsync(dto));
    }
    [Test]
    public async Task DeleteAsync_WhenDirectorIsNotPresent_ShouldThrowBusinessException()
    {
        // Arrange
        long id = 1;
        _directorBusinessRules.Setup(x => x.DirectorIsPresent(id)).ThrowsAsync(new BusinessException("Director is not present"));
        // Act & Assert
        var ex = Assert.ThrowsAsync<BusinessException>(() => _directorService.DeleteAsync(id));
        Assert.AreEqual(ex.Message, "Director is not present");
    }
    [Test]
    public async Task DeleteAsync_WhenDirectorIsPresent_ShouldNotThrowException()
    {
        // Arrange
    }
}
