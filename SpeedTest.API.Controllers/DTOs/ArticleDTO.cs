using SpeedTest.Context.Models;

namespace SpeedTest.API.Controllers.DTOs
{
    public class ArticleDTO
    {
        public int ArticleId { get; set; }

        public string ArticleName { get; set; } = null!;

        public string ArticleContent { get; set; } = null!;

        public int AuthorId { get; set; }

    }
}
