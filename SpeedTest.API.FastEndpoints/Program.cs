using FastEndpoints;
using SpeedTest.Repository.Interfaces;
using SpeedTest.Repository;
using Microsoft.EntityFrameworkCore;
using SpeedTest.Context.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SpeedTestContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SpeedTestConnection"));
});

// Add services to the container.
builder.Services.AddFastEndpoints();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ISiteUserRepository, SiteUserRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IArticleRatingRepository, ArticleRatingRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseFastEndpoints();

app.Run();
