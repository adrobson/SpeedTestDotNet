using FastEndpoints;
using SpeedTest.API.FastEndpoints.DTOs.Articles;
using SpeedTest.Context.Models;
using SpeedTest.Repository.Interfaces;

namespace SpeedTest.API.FastEndpoints.Endpoints.Articles
{

    public class AddArticle : Endpoint<RequestDTO, ResponseDTO>
    {
        public IArticleRepository _articleRepository { get; set; }

        public override void Configure()
        {
            Post("/article/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(RequestDTO newArticleDTO, CancellationToken ct)
        {
            var newArticle = new Article
            {
                ArticleName = newArticleDTO.ArticleName,
                ArticleContent = newArticleDTO.ArticleContent,
                AuthorId = newArticleDTO.AuthorId
            };

            await _articleRepository.Insert(newArticle);

            await SendAsync(new()
            {
                ArticleId = newArticle.ArticleId,
                ArticleName = newArticle.ArticleName,
                ArticleContent = newArticle.ArticleContent,
                AuthorId = newArticle.AuthorId
            });
        }
    }
}
