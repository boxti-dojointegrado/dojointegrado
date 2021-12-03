using BoxTI.DojoIntegrado.Domain.Interfaces;

namespace BoxTI.DojoIntegrado.Services.PasswordHasher
{
    public class BCryptPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
