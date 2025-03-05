using System.Text.Json;

namespace Core.CrossCuttingConcerns.Exceptions.Extensions;

public static class ProblemDetailsExtension
{
    // Extension methodlarin kullanim amaci,
    // this anahtar kelimesi genisleme yapilacak sinifi belirtir.
    // Ilgili problemDetails nesnesini json formatina cevirir.
    public static string AsJson<TProblemDetails>(this TProblemDetails details)
    {
        return JsonSerializer.Serialize(details);
    }
}