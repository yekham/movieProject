using Core.CrossCuttingConcerns;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security;
using Core.Security.Encryption;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MovieProject.DataAccess;
using MovieProject.DataAccess.Contexts;
using MovieProject.DataAccess.Repositories.Abstracts;
using MovieProject.DataAccess.Repositories.Concretes;
using MovieProject.Service;
using MovieProject.Service.Abstracts;
using MovieProject.Service.BusinessRules.Artists;
using MovieProject.Service.BusinessRules.Categories;
using MovieProject.Service.BusinessRules.Movies;
using MovieProject.Service.Concretes;
using MovieProject.Service.Helpers;
using MovieProject.Service.Mappers.Categories;
using MovieProject.Service.Mappers.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Dependency Injection Lifecycle (Ya�am D�ng�s�)
// AddScopped() : Uygulama boyunca 1 tane nesne �retir. Nesnenin �mr� ise istek cevaba d�nene kadar.
// AddSingleton() : Uygulama boyunca 1 tane nesne uretir.
// AddTransient(): Uygulamada her istek i�in ayr� bir nesne olu�turur.

builder.Services.AddHttpContextAccessor();



builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

//Jwt ioC kayitlarini yapilandiriyoruz.
builder.Services.AddSecurityDependencies();

//Veri tabani baglantilarini yapilandiriyoruz.
builder.Services.AddDataAccessDependencies(builder.Configuration);

//Service katmanindaki bagimliliklari yapilandiriyoruz.
builder.Services.AddServiceDependencies();

builder.Services.AddControllers();
builder.Services.AddRedisDistributedCacheDependency();

builder.Services.AddStackExchangeRedisCache(opt =>
{
    opt.Configuration = "localhost:6379";
    opt.InstanceName = "MovieProjectCache_";
});

TokenOptions tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };

    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
//app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();