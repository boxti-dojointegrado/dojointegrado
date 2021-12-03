using BoxTI.DojoIntegrado.API.Models.Request;
using BoxTI.DojoIntegrado.API.Models.Response;
using BoxTI.DojoIntegrado.Domain.Entities;
using BoxTI.DojoIntegrado.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoxTI.DojoIntegrado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthController(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if (PasswordDontMatchWithConfirmation(registerRequest))
                return BadRequest("Password does not match with confirm password.");

            if (await EmailIsAlreadyRegistered(registerRequest.Email))
                return BadRequest("Email address already registered");

            var passwordHash = _passwordHasher.HashPassword(registerRequest.Password);

            var newUser = new User()
            {
                Email = registerRequest.Email,
                Password = passwordHash,
                Role = registerRequest.Role
            };

            await _userRepository.Create(newUser);

            return Ok(new UserResponse(registerRequest.Email));
        }

        private static bool PasswordDontMatchWithConfirmation(RegisterRequest registerRequest)
        {
            return registerRequest.Password != registerRequest.ConfirmPassword;
        }

        private async Task<bool> EmailIsAlreadyRegistered(string email)
        {
            return await _userRepository.GetByEmail(email) is not null;
        }
    }
}
