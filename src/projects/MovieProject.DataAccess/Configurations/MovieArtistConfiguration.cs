using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.DataAccess.Configurations;

public sealed class MovieArtistConfiguration : IEntityTypeConfiguration<MovieArtist>
{
    public void Configure(EntityTypeBuilder<MovieArtist> builder)
    {
        builder.ToTable("MovieArtist").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("MovieArtistId").IsRequired();
        builder.Property(x => x.CreatedTime).HasColumnName("Created").IsRequired();
        
        builder
            .HasOne( x => x.Artist)
            .WithMany(x => x.MovieArtists)
            .HasForeignKey(x => x.ArtistId);
        
        builder
            .HasOne(x => x.Movie)
            .WithMany(x => x.MovieArtists)
            .HasForeignKey(x => x.MovieId);
       
    }
}
