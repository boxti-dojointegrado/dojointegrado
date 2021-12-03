using AutoMapper;
using BoxTI.DojoIntegrado.Domain.Entities;
using BoxTI.DojoIntegrado.Services.DTOs;

namespace BoxTI.DojoIntegrado.Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
}
