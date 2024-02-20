using FastEndpoints;
using SpeedTest.API.FastEndpoints.DTOs.ArticleRatings;
using SpeedTest.API.FastEndpoints.DTOs.Articles;
using SpeedTest.Context.Models;
using SpeedTest.Repository.Interfaces;

namespace SpeedTest.API.FastEndpoints.Endpoints.ArticleRatings
{

    public class DeleteLastArticleRatings : EndpointWithoutRequest
    {
        public IArticleRatingRepository _articleRatingRepository { get; set; }

        public override void Configure()
        {
            Delete("/articleRating/delete/last");
            AllowAnonymous();
        }

        public override Task HandleAsync(CancellationToken ct)
        {
            _articleRatingRepository.DeleteLast();

            return Task.CompletedTask;
        }
    }
}
