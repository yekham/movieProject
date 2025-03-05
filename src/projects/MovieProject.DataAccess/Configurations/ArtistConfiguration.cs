using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.DataAccess.Configurations;

public sealed class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.ToTable("Artists").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ArtistId").IsRequired();
        builder.Property(x => x.CreatedTime).HasColumnName("Created").IsRequired();
        builder.Property(x => x.Name).HasColumnName("ArtistName").IsRequired();
        
        builder.HasMany(x => x.MovieArtists);
        
    }
}
