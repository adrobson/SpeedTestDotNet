using FastEndpoints;
using SpeedTest.API.FastEndpoints.DTOs.ArticleRatings;
using SpeedTest.API.FastEndpoints.DTOs.Articles;
using SpeedTest.Context.Models;
using SpeedTest.Repository.Interfaces;

namespace SpeedTest.API.FastEndpoints.Endpoints.ArticleRatings
{

    public class GetLastArticleRatings : Endpoint<NumArticleRatingsRequestDTO, IEnumerable<ArticleRating>>
    {
        public IArticleRatingRepository _articleRatingRepository { get; set; }

        public override void Configure()
        {
            Get("/articleRating/last/{numArticleRatings}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(NumArticleRatingsRequestDTO numArticleRatings, CancellationToken ct)
        {
            var lastArticleRatings = await _articleRatingRepository.Last(numArticleRatings.NumArticleRatings);

            await SendAsync(lastArticleRatings);
        }
    }
}
