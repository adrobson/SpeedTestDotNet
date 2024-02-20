using FastEndpoints;
using SpeedTest.API.FastEndpoints.DTOs.ArticleRatings;
using SpeedTest.API.FastEndpoints.DTOs.Articles;
using SpeedTest.Context.Models;
using SpeedTest.Repository;
using SpeedTest.Repository.Interfaces;

namespace SpeedTest.API.FastEndpoints.Endpoints.ArticleRatings
{

    public class DeleteArticleRatings : EndpointWithoutRequest
    {
        public IArticleRatingRepository _articleRatingRepository { get; set; }

        public override void Configure()
        {
            Delete("/articleRating/{articleRatingId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            int articleRatingId = Route<int>("articleRatingId");

            await _articleRatingRepository.Delete(articleRatingId);

            await SendOkAsync();
        }
    }
}
