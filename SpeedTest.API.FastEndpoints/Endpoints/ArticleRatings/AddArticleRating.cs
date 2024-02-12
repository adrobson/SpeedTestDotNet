using FastEndpoints;
using SpeedTest.API.FastEndpoints.DTOs.ArticleRatings;
using SpeedTest.Context.Models;
using SpeedTest.Repository.Interfaces;

namespace SpeedTest.API.FastEndpoints.Endpoints.Articles
{

    public class AddArticleRating : Endpoint<RequestDTO, ResponseDTO>
    {
        public IArticleRatingRepository _articleRatingRepository { get; set; }

        public override void Configure()
        {
            Post("/articleRating/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(RequestDTO newArticleDTO, CancellationToken ct)
        {
            var newArticleRating = new ArticleRating
            {
                ArticleId = newArticleDTO.ArticleId,
                SiteUserId = newArticleDTO.SiteUserId,
                Rating = newArticleDTO.Rating,
                RatingDate = newArticleDTO.RatingDate
            };

            await _articleRatingRepository.Insert(newArticleRating);

            await SendAsync(new()
            {
                ArticleRatingId = newArticleRating.ArticleRatingId,
                ArticleId = newArticleRating.ArticleId,
                SiteUserId = newArticleRating.SiteUserId,
                Rating = newArticleRating.Rating,
                RatingDate = newArticleRating.RatingDate
            });
        }
    }
}
