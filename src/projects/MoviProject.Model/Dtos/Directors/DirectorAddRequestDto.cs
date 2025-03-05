using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MovieProject.Model.Dtos.Directors;

public sealed record DirectorAddRequestDto
{
    public string? Name { get; init; }
    public string? Surname { get; init; }
    public IFormFile? Image { get; init; }
    public DateTime BirthDate { get; init; }
}