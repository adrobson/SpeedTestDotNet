using SpeedTest.Context.Models;

namespace SpeedTest.API.Controllers.DTOs
{
    public class SiteUserDTO
    {
        public int SiteUserId { get; set; }

        public string SiteUserName { get; set; } = null!;
    }
}
