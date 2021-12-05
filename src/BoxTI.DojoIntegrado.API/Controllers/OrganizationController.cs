using AutoMapper;
using BoxTI.DojoIntegrado.Domain.Entities;
using BoxTI.DojoIntegrado.Infrastructure.Data.Repositories.Interfaces;
using BoxTI.DojoIntegrado.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BoxTI.DojoIntegrado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;

        public OrganizationController(
            IOrganizationRepository organizationRepository, 
            IMapper mapper
        )
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var organizations = await _organizationRepository.GetAllAsync();

                return Ok(_mapper.Map<IEnumerable<OrganizationDTO>>(organizations));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var organization = await _organizationRepository.GetByIdAsync(id);

                return Ok(_mapper.Map<OrganizationDTO>(organization));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrganizationDTO request)
        {
            try
            {
                await _organizationRepository.AddAsync(_mapper.Map<Organization>(request));

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] OrganizationDTO request)
        {
            try
            {
                await _organizationRepository.UpdateAsync(_mapper.Map<Organization>(request));

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _organizationRepository.RemoveAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
