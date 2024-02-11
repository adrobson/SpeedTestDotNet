using SpeedTest.API.Minimal.DTOs;
using SpeedTest.Context.Models;

namespace SpeedTest.API.Minimal.Mappers
{
    public class MapObjectToDTO
    {

        public static ArticleRatingDTO ArticleRatingToDTO(ArticleRating ArticleRating) =>
            new ArticleRatingDTO
            {
                ArticleRatingId = ArticleRating.ArticleRatingId,
                ArticleId = ArticleRating.ArticleId,
                SiteUserId = ArticleRating.SiteUserId,
                Rating = ArticleRating.Rating,
                RatingDate = ArticleRating.RatingDate
            };
    }
}
