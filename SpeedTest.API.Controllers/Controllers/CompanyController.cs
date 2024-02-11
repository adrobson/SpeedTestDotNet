using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeedTest.API.Controllers.DTOs;
using SpeedTest.Context.Models;
using SpeedTest.Repository.Interfaces;

namespace SpeedTest.API.Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyRepository _CompanyRepository;

        public CompanyController(ILogger<CompanyController> logger,
            ICompanyRepository CompanyRepository)
        {
            _logger = logger;
            _CompanyRepository = CompanyRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDTO>> GetCompany(int id)
        {
            var company = await _CompanyRepository.GetOne(id);
            if(company == null)
            {
                return NotFound();
            }

            return ItemToDTO(company);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDTO>> AddCompany(CompanyDTO newCompanyDTO)
        {
            var newCompany = new Company
            {
                CompanyName = newCompanyDTO.CompanyName
            };

            await _CompanyRepository.Insert(newCompany);

            return CreatedAtAction(nameof(GetCompany),
                new {id = newCompany.CompanyId},
                ItemToDTO(newCompany));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyDTO>> UpdateCompany(int id, Company company)
        {
            if(id != company.CompanyId)
            {
                return BadRequest();
            }

            await _CompanyRepository.Update(company);

            return ItemToDTO(company);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            await _CompanyRepository.Delete(id);

            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<Company>> Get()
        {
            return await _CompanyRepository.All();
        }

        private static CompanyDTO ItemToDTO(Company company)
        {
            return new CompanyDTO
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName
            };
        }
    }
}
