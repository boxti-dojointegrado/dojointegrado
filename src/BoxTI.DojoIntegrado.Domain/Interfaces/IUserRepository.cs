using BoxTI.DojoIntegrado.Domain.Entities;

namespace BoxTI.DojoIntegrado.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);

        Task<User> Create(User user);

        Task<User> GetById(int userId);
    }
}
