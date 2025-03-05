using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Model.Dtos.Artists;
//Record kullanmamizin nedeni immutable olmasi
//Recordlar immutable oldugu icin daha guvenli ve daha performansli calisir
//Recordlarin icinde readonly propertyler olur
public record ArtistAddRequestDto
{
    public string? Name { get; init; }
    public string? Surname { get; init; }
    public IFormFile? Image { get; init; }
    public DateTime BirthDate { get; init; }
}

//Record - miras miras iliskisi olur 

//Record - class miras iliskisi olmaz

//Record - interface miras iliskisi olur