using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Model.Dtos.MovieArtists;
public sealed record MovieArtistAddRequestDto
{
    public long ArtistId { get; init; }
    public Guid MovieId { get; init; }
}