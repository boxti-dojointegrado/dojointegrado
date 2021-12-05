using AutoMapper;
using BoxTI.DojoIntegrado.Domain.Entities;
using BoxTI.DojoIntegrado.Infrastructure.Data.Repositories.Interfaces;
using BoxTI.DojoIntegrado.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BoxTI.DojoIntegrado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressController(
            IAddressRepository addressRepository, 
            IMapper mapper
        )
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var addresses = await _addressRepository.GetAllAsync();

                return Ok(_mapper.Map<IEnumerable<AddressDTO>>(addresses));
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
                var address = await _addressRepository.GetByIdAsync(id);

                return Ok(_mapper.Map<AddressDTO>(address));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddressDTO request)
        {
            try
            {
                await _addressRepository.AddAsync(_mapper.Map<Address>(request));

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AddressDTO request)
        {
            try
            {
                await _addressRepository.UpdateAsync(_mapper.Map<Address>(request));

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
                await _addressRepository.RemoveAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
