using FastEndpoints;
using SpeedTest.API.FastEndpoints.DTOs.ArticleRatings;
using SpeedTest.Context.Models;
using SpeedTest.Repository.Interfaces;

namespace SpeedTest.API.FastEndpoints.Endpoints.ArticleRatings
{

    public class UpdateArticleRatings : Endpoint<ResponseDTO, ResponseDTO>
    {
        public IArticleRatingRepository _articleRatingRepository { get; set; }

        public override void Configure()
        {
            Put("/articleRating/{articleRatingId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(ResponseDTO articleRatingDTO, CancellationToken ct)
        {
            int articleRatingId = Route<int>("articleRatingId");
            if (articleRatingId != articleRatingDTO.ArticleRatingId)
            {
                await SendErrorsAsync();
            }

            var ArticleRating = await _articleRatingRepository.GetOne(articleRatingId);
            ArticleRating.ArticleId = articleRatingDTO.ArticleId;
            ArticleRating.SiteUserId = articleRatingDTO.SiteUserId;
            ArticleRating.Rating = articleRatingDTO.Rating;
            ArticleRating.RatingDate = articleRatingDTO.RatingDate;

            await _articleRatingRepository.Update(ArticleRating);

            await SendOkAsync();
        }
    }
}
