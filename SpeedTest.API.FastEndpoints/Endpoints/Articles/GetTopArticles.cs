using FastEndpoints;
using SpeedTest.API.FastEndpoints.DTOs.Articles;
using SpeedTest.Context.Models;
using SpeedTest.Repository.Interfaces;

namespace SpeedTest.API.FastEndpoints.Endpoints.Articles
{

    public class GetTopArticles : Endpoint<NumArticlesRequestDTO, IEnumerable<Article>>
    {
        public IArticleRepository _articleRepository { get; set; }

        public override void Configure()
        {
            Get("/article/top/{numArticles}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(NumArticlesRequestDTO numArticles, CancellationToken ct)
        {
            var topArticles = await _articleRepository.Top(numArticles.NumArticles);

            await SendAsync(topArticles);
        }
    }
}
