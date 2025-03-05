using Microsoft.EntityFrameworkCore;
using MovieProject.Model.Entities;

namespace MovieProject.DataAccess.Configurations;

public sealed class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Director> builder)
    {
        builder.ToTable("Directors").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("DirectorId").IsRequired();
        builder.Property(x => x.CreatedTime).HasColumnName("Created").IsRequired();
        
        builder
            .HasMany(x => x.Movies)
            .WithOne(x => x.Director)
            .HasForeignKey(x => x.DirectorId);

        builder.HasData(
            new Director { Id = 1, Name = "Christopher", Surname = "Nolan", ImageUrl = "", BirthDate = new DateTime(1970, 7, 30), CreatedTime = DateTime.UtcNow },
            new Director
            {
                Id = 2,
                Name = "Quentin",
                Surname = "Tarantino",
                ImageUrl = "https://www.google.com",
                BirthDate = new DateTime(1963, 3, 27),
                CreatedTime = DateTime.UtcNow
            },
            new Director
            {
                Id = 3,
                Name = "Martin",
                Surname = "Scorsese",
                ImageUrl = "https://www.google.com",
                BirthDate = new DateTime(1942, 11, 17),
                CreatedTime = DateTime.UtcNow
            }
        );
    }
}
