using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.DataAccess.Configurations;

public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("CategoryId").IsRequired();
        builder.Property(x => x.CreatedTime).HasColumnName("Created").IsRequired();
        builder.Property(x => x.Name).HasColumnName("CategoryName").IsRequired();
        builder.HasMany(x => x.Movies);
        builder.HasData(
            new Category { Id = 1, Name = "Action", CreatedTime = DateTime.UtcNow },
            new Category { Id = 2, Name = "Mystery", CreatedTime = DateTime.UtcNow },
            new Category { Id = 3, Name = "Sci-Fi", CreatedTime = DateTime.UtcNow }
        );
    }
}
