using Core.CrossCuttingConcerns.Exceptions.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions;

public class ExceptionMiddleware
{

    //Istek ve yanit arasinda yapilan islemlere middleware denir.
    //Yetkilendirme, dogrulama, hata yakalama, loglama, vs. gibi islemler middleware ile yapilir.
    private readonly HttpExceptionHandler _exceptionHandler;

    //Middleware'ler arasinda gecis yapmamizi saglar.
    //Ilgili middleware'ler arasindaki iletisimi kuran yapidir.
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
        _exceptionHandler = new HttpExceptionHandler();
    }


    // async - await- Task 
    //Kesinlikle bir invoke methodu olmalidir.
    public async Task Invoke(HttpContext context)
    {
        //Uygulama boyunca tek bir try-catch blogu olusturulur.
        //Bu sayede hata yakalama islemleri tek bir yerde toplanmis olur.
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context.Response, e);
        }
    }
    private Task HandleExceptionAsync(HttpResponse response, Exception exception)
    {
        response.ContentType = "application/json";
        _exceptionHandler.Response = response;
        return _exceptionHandler.HandleExceptionAsync(exception);
    }
    
    
    //Bu yapi ile controller'da olusan hatalari yakalayip, uygun bir sekilde kullaniciya donduruyoruz.
    //Yani controller'da try-catch yazmamiza gerek yok.
    //Ornek olarak bu yapiyi kullanmasaydik controller'da soyle bir yapi olusturucaktik.
    /*
     
    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        try
        {
            var result = _categoryService.GetById(id);
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    */
}