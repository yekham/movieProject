namespace MovieProject.Model.Dtos.Artists;

public record ArtistResponseDto
{
    public long Id { get; init; }
    public string? ImageUrl { get; init; }

    public DateTime BirthDate { get; init; }
    public string? FullName { get; init; }
}