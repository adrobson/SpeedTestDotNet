using SpeedTest.Context.Models;

namespace SpeedTest.API.FastEndpoints.DTOs.SiteUsers
{
    public class ResponseDTO
    {
        public int SiteUserId { get; set; }

        public string SiteUserName { get; set; } = null!;
    }
}
