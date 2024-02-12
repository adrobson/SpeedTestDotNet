using SpeedTest.Context.Models;

namespace SpeedTest.API.FastEndpoints.DTOs.Articles
{
    public class ResponseDTO
    {
        public int ArticleId { get; set; }

        public string ArticleName { get; set; } = null!;

        public string ArticleContent { get; set; } = null!;

        public int AuthorId { get; set; }

    }
}
