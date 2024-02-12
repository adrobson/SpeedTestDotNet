using Microsoft.EntityFrameworkCore;
using SpeedTest.Context.Models;
using SpeedTest.Repository.Interfaces;
using SpeedTest.Repository;
using SpeedTest.API.Minimal.DTOs;
using SpeedTest.API.Minimal.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SpeedTestContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SpeedTestConnection")));

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ISiteUserRepository, SiteUserRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IArticleRatingRepository, ArticleRatingRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapPost("/articleRating", async Task<Results<Ok<ArticleRatingDTO>, BadRequest>> (ArticleRatingDTO newArticleRatingDTO) =>
{
    using (var scope = app.Services.CreateScope())
    {
        var _articleRatingRepository = scope.ServiceProvider.GetRequiredService<IArticleRatingRepository>();
        var newArticleRating = new ArticleRating
        {
            ArticleId = newArticleRatingDTO.ArticleId,
            SiteUserId = newArticleRatingDTO.SiteUserId,
            Rating = newArticleRatingDTO.Rating,
            RatingDate = newArticleRatingDTO.RatingDate
        };

        await _articleRatingRepository.Insert(newArticleRating);

        return TypedResults.Ok(MapObjectToDTO.ArticleRatingToDTO(newArticleRating));
    }
});

app.MapPut("/articleRating/{id}", async Task<Results<Ok<ArticleRatingDTO>, BadRequest>> (int id, ArticleRatingDTO articleRatingDTO) =>
{
    using (var scope = app.Services.CreateScope())
    {
        var _articleRatingRepository = scope.ServiceProvider.GetRequiredService<IArticleRatingRepository>();
        if (id != articleRatingDTO.ArticleRatingId)
        {
            return TypedResults.BadRequest();
        }

        var articleRating = await _articleRatingRepository.GetOne(id);
        articleRating.ArticleId = articleRatingDTO.ArticleId;
        articleRating.SiteUserId = articleRatingDTO.SiteUserId;
        articleRating.Rating = articleRatingDTO.Rating;
        articleRating.RatingDate = articleRatingDTO.RatingDate;

        await _articleRatingRepository.Update(articleRating);

        return TypedResults.Ok(MapObjectToDTO.ArticleRatingToDTO(articleRating));
    }
});

app.MapDelete("/articleRating/{id}", async (int id) =>
{
    using (var scope = app.Services.CreateScope())
    {
        var _articleRatingRepository = scope.ServiceProvider.GetRequiredService<IArticleRatingRepository>();
        await _articleRatingRepository.Delete(id);

        return Results.NoContent();
    }
});

app.MapGet("/articleRating/{id}", async (int id) =>
{
    using (var scope = app.Services.CreateScope())
    {
        var _articleRatingRepository = scope.ServiceProvider.GetRequiredService<IArticleRatingRepository>();
        return await _articleRatingRepository.GetOne(id);
    }
});

app.MapGet("/articleRating", async () =>
{
    using (var scope = app.Services.CreateScope())
    {
        var _articleRatingRepository = scope.ServiceProvider.GetRequiredService<IArticleRatingRepository>();
        return await _articleRatingRepository.All();
    }
});

app.MapGet("/author", async () =>
{
    using (var scope = app.Services.CreateScope())
    {
        var _authorRepository = scope.ServiceProvider.GetRequiredService<IAuthorRepository>();
        return await _authorRepository.All();
    }
});

app.MapGet("/author/top/{numAuthors}", (int numAuthors) =>
{
    using (var scope = app.Services.CreateScope())
    {
        var _authorRepository = scope.ServiceProvider.GetRequiredService<IAuthorRepository>();
        return _authorRepository.Top(numAuthors);
    }
});

app.MapGet("/article/top/{numArticles}", async (int numArticles) =>
{
    using (var scope = app.Services.CreateScope())
    {
        var _articleRepository = scope.ServiceProvider.GetRequiredService<IArticleRepository>();
        return await _articleRepository.Top(numArticles);
    }
});

app.Run();
