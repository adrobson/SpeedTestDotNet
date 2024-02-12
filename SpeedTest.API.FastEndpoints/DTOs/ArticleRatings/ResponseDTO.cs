using SpeedTest.Context.Models;

namespace SpeedTest.API.FastEndpoints.DTOs.ArticleRatings
{
    public class ResponseDTO
    {
        public int ArticleRatingId { get; set; }

        public int ArticleId { get; set; }

        public int SiteUserId { get; set; }

        public int Rating { get; set; }

        public DateTime RatingDate { get; set; }

    }
}
