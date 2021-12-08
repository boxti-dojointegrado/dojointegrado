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

            CreateMap<Organization, GetOrganizationDTO>()
                .ForMember(e => e.AddressDTO, dest => dest.MapFrom(src => src.Address))
                .ReverseMap();

            CreateMap<Organization, PostOrganizationDTO>()
                .ForMember(e => e.AddressDTO, dest => dest.MapFrom(src => src.Address))
                .ReverseMap();

            CreateMap<Company, CompanyDTO>()
                .ForMember(e => e.Id, dest => dest.MapFrom(src => src.OrganizationId))
                .ForMember(e => e.CorporateName, dest => dest.MapFrom(src => src.Organization.CorporateName))
                .ForMember(e => e.FantasyName, dest => dest.MapFrom(src => src.Organization.FantasyName))
                .ForMember(e => e.Cnpj, dest => dest.MapFrom(src => src.Organization.Cnpj))
                .ForMember(e => e.Phone, dest => dest.MapFrom(src => src.Organization.Phone))
                .ForMember(e => e.Description, dest => dest.MapFrom(src => src.Organization.Description))
                .ForMember(e => e.AddressDTO, dest => dest.MapFrom(src => src.Organization.Address))
                .ReverseMap();

            CreateMap<Ngo, NgoDTO>()
                .ForMember(e => e.Id, dest => dest.MapFrom(src => src.OrganizationId))
                .ForMember(e => e.CorporateName, dest => dest.MapFrom(src => src.Organization.CorporateName))
                .ForMember(e => e.FantasyName, dest => dest.MapFrom(src => src.Organization.FantasyName))
                .ForMember(e => e.Cnpj, dest => dest.MapFrom(src => src.Organization.Cnpj))
                .ForMember(e => e.Phone, dest => dest.MapFrom(src => src.Organization.Phone))
                .ForMember(e => e.Description, dest => dest.MapFrom(src => src.Organization.Description))
                .ForMember(e => e.AddressDTO, dest => dest.MapFrom(src => src.Organization.Address))
                .ReverseMap();
        }
    }
}
