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
        private readonly ITokenService _tokenService;

        public AuthController(
            IUserRepository userRepository, 
            IPasswordHasher passwordHasher, 
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
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

            return Ok(new UserResponse(registerRequest.Email, _tokenService.GenerateToken(newUser)));
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserResponse>> Login([FromBody] LoginRequest loginRequest)
        {
            var logedinUser = await _userRepository.GetByEmail(loginRequest.Email);
            if (logedinUser is null) return Unauthorized();

            var isCorrectPassword = _passwordHasher.VerifyPassword(loginRequest.Password, logedinUser.Password);
            if (isCorrectPassword) return Ok(new UserResponse(logedinUser.Email, _tokenService.GenerateToken(logedinUser)));

            return Unauthorized();
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
