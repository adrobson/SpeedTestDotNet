using SpeedTest.Context.Models;

namespace SpeedTest.API.FastEndpoints.DTOs.Companys
{
    public class ResponseDTO
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; } = null!;
    }
}
