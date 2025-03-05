using Core.DataAccess.Entities;
namespace MovieProject.Model.Entities;

public sealed class Movie : Entity<Guid>
{
    //Hic bir sekilde kisitlama yapmadigi icin ilgili alanlar kacirilabilir , hata vermez
    public Movie()
    {
        Name = string.Empty;
        Description = string.Empty;
        ImageUrl = string.Empty;
        Category = new Category();
        MovieArtists = new HashSet<MovieArtist>();
        Director = new Director();
    }
    // Movie movie = new Movie(){
    // Id = Guid.NewGuid(),
    // CategoryId = 1,
    // DateTime = DateTime.now}; => Ornek kullanim seneryosu

    
    
    //Kullanicidan zorunlu olarak almak istedigim verileri ekleme islemi yaparken kullanmak gerekir.
    public Movie(Guid id, 
        string name, 
        string description, 
        double imdb, 
        DateTime publish, 
        string imageUrl,
        bool isActive,
        int categoryId,
        long directorId) : base(id)
    {
        Name = name;
        Description = description;
        IMDB = imdb;
        PublishDate = publish;
        ImageUrl = imageUrl;
        IsActive = isActive;
        CategoryId = categoryId;
        DirectorId = directorId;
        Category = new Category();
        MovieArtists = new HashSet<MovieArtist>();
        Director = new Director();
    }
    // Movie movie1 = new Movie(Guid.NewGuid(), ""Deneme, "deneme", 10, DateTime.Now, "img.url", True, 1, 2); => Ornek kullanim seneryosu

    public Movie(string name, string description, double imdb, DateTime publish, string imageUrl, bool isActive, int categoryId, long directorId) : this(default , name, description, imdb, publish, imageUrl, isActive, categoryId, directorId)
    {}
    // Movie movie2 = new Movie("Deneme", "deneme", 10, DateTime.Now, "img.url", True, 1, 2); => Ornek kullanim seneryosu
    public string Name { get; set; }

    public string Description { get; set; }

    public double IMDB { get; set; }

    public DateTime PublishDate { get; set; }

    public string ImageUrl { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public bool IsActive { get; set; }
    public ICollection<MovieArtist> MovieArtists { get; set; }


    public long DirectorId { get; set; }
    public Director Director { get; set; }
}