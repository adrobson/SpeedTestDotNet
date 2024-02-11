using SpeedTest.Context.Models;

namespace SpeedTest.API.Minimal.DTOs
{
    public class ArticleRatingDTO
    {
        public int ArticleRatingId { get; set; }

        public int ArticleId { get; set; }

        public int SiteUserId { get; set; }

        public int Rating { get; set; }

        public DateTime RatingDate { get; set; }

    }
}
