using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SpeedTest.Context.Models;
using SpeedTest.Repository;
using SpeedTest.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add a dbcontext .
// Note that "Scoped" is the default choice of ServiceLifetime in AddDbContext. 
builder.Services.AddDbContext<SpeedTestContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SpeedTestConnection"));
});

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ISiteUserRepository, SiteUserRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IArticleRatingRepository, ArticleRatingRepository>();
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
