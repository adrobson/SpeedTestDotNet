using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeedTest.API.Controllers.DTOs;
using SpeedTest.Context.Models;
using SpeedTest.Repository.Interfaces;

namespace SpeedTest.API.Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SiteUserController : ControllerBase
    {
        private readonly ILogger<SiteUserController> _logger;
        private readonly ISiteUserRepository _siteUserRepository;

        public SiteUserController(ILogger<SiteUserController> logger,
            ISiteUserRepository siteUserRepository)
        {
            _logger = logger;
            _siteUserRepository = siteUserRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SiteUserDTO>> GetSiteUser(int id)
        {
            var SiteUser = await _siteUserRepository.GetOne(id);
            if(SiteUser == null)
            {
                return NotFound();
            }

            return ItemToDTO(SiteUser);
        }

        [HttpPost]
        public async Task<ActionResult<SiteUserDTO>> AddSiteUser(SiteUserDTO newSiteUserDTO)
        {
            var newSiteUser = new SiteUser
            {
                SiteUserName = newSiteUserDTO.SiteUserName
            };

            await _siteUserRepository.Insert(newSiteUser);

            return CreatedAtAction(nameof(GetSiteUser),
                new {id = newSiteUser.SiteUserId},
                ItemToDTO(newSiteUser));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SiteUserDTO>> UpdateSiteUser(int id, SiteUser siteUser)
        {
            if(id != siteUser.SiteUserId)
            {
                return BadRequest();
            }

            await _siteUserRepository.Update(siteUser);

            return ItemToDTO(siteUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSiteUser(int id)
        {
            await _siteUserRepository.Delete(id);

            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<SiteUser>> Get()
        {
            return await _siteUserRepository.All();
        }

        private static SiteUserDTO ItemToDTO(SiteUser SiteUser)
        {
            return new SiteUserDTO
            {
                SiteUserId = SiteUser.SiteUserId,
                SiteUserName = SiteUser.SiteUserName
            };
        }
    }
}
