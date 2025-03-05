using MovieProject.Model.Dtos.Directors;

namespace Service.Test.Utils;

public static class DirectorUtils
{
    public static DirectorAddRequestDto AddRequestDto() 
    {
        return new DirectorAddRequestDto
        {
            Name = "James",
            Surname = "Cameron",
            Image = null,
            BirthDate = new DateTime(1954, 8, 16)

        };
    }
}
