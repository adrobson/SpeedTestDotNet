using SpeedTest.Context.Models;

namespace SpeedTest.API.Minimal.DTOs
{
    public class CompanyDTO
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; } = null!;
    }
}
