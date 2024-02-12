using SpeedTest.Context.Models;

namespace SpeedTest.API.FastEndpoints.DTOs.Authors
{
    public class ResponseDTO
    {
        public int AuthorId { get; set; }

        public string AuthorName { get; set; } = null!;

        public int CompanyId { get; set; }

    }
}
