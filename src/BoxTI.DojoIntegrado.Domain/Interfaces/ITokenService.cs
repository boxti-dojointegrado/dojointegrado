using BoxTI.DojoIntegrado.Domain.Entities;

namespace BoxTI.DojoIntegrado.Domain.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
