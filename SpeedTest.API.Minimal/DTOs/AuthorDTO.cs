using SpeedTest.Context.Models;

namespace SpeedTest.API.Minimal.DTOs
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }

        public string AuthorName { get; set; } = null!;

        public int CompanyId { get; set; }

    }
}
