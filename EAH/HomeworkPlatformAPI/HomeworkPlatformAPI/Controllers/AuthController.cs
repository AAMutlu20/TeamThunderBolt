using HomeworkPlatformAPI.DTOs.Requests;
using HomeworkPlatformAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HomeworkPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfigurationSection _jwtSettings;

        public AuthController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _jwtSettings = configuration.GetSection("JwtSettings");
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserRequestDTO userModel)
        {
            var authUser = await _userManager.FindByEmailAsync(userModel.Email);

            if (authUser != null && await _userManager.CheckPasswordAsync(authUser, userModel.Password))
            {
                var signingCredentials = GetSigningCredentials();
                var claims = GetClaims(authUser);
                var tokenOptions = GenerateTokenOptions(signingCredentials, await claims);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(token);
            }
            else
            {
                return Unauthorized("Invalid Auth");
            }

        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(UserRegisterRequestDTO userModel)
        {
            var user = new User()
            {
                Email = userModel.Email,
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
            };
            var userCreated = await _userManager.CreateAsync(user, userModel.Password);

            if (userCreated.Succeeded)
            {
                return StatusCode(201);
            }
            else
            {
                return BadRequest(userCreated.Errors);
            }
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings.GetSection("validIssuer").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("expiryInMinutes").Value)),
                signingCredentials: signingCredentials
                );
            return tokenOptions;
        }

        private async Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Email)
            };

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

    }
}
