using SpeedTest.Context.Models;

namespace SpeedTest.API.Minimal.DTOs
{
    public class ArticleDTO
    {
        public int ArticleId { get; set; }

        public string ArticleName { get; set; } = null!;

        public string ArticleContent { get; set; } = null!;

        public int AuthorId { get; set; }

    }
}
