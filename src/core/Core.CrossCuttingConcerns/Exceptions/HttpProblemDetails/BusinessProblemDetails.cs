using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

// 
public sealed class BusinessProblemDetails : ProblemDetails
{
    //Kullaniciya exception dusmesi durumunda bu nesneleri donduruyoruz.
    public BusinessProblemDetails(string detail)
    {
        Title = "Business Exception";
        Detail = detail;
        Status = StatusCodes.Status400BadRequest;
        Type = "http://example.com/problems/business";
    }
}