using BoxTI.DojoIntegrado.Infrastructure.Data.Repositories;
using BoxTI.DojoIntegrado.Infrastructure.Data.Repositories.Interfaces;
using BoxTI.DojoIntegrado.Services.AutoMapper;

namespace BoxTI.DojoIntegrado.API.Configurations;

public static class ServicesConfiguration
{
    public static IServiceCollection AddServicesConfig(this IServiceCollection services)
    {
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<INgoRepository, NgoRepository>();
        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}