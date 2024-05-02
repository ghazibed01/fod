using fod.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using fod.Services;

namespace JwtWebApiDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public UserController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpGet, Authorize]
        public ActionResult<string> GetMyName()
        {
            return Ok(_userService.GetName());

            //var email = User?.Identity?.Name;
            //var roleClaims = User?.FindAll(ClaimTypes.Role);
            //var roles = roleClaims?.Select(c => c.Value).ToList();
            // var roles2 = User?.Claims
            //.Where(c => c.Type == ClaimTypes.Role)
            //.Select(c => c.Value)
            //  .ToList();
            //  return Ok(new { email, roles, roles2 });
        }

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.Email = request.Email;
            user.PasswordHash = passwordHash;

            return Ok(user);
        }
        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshtoken = Request.Cookies["RefreshToken"];
            if (!user.RefreshToken.Equals(refreshtoken))
            {
                return Unauthorized("Invalid refresh token");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Invalid token EXPIRES");

            }
            string Token = CreateToken(user);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken);
            return Ok(Token);

        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserDto request)
        {
            if (user.Email != request.Email)
            {
                return BadRequest("User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(user);
            var refresToken = GenerateRefreshToken();
            SetRefreshToken(refresToken);

            return Ok(token);
        }
        private RefreshToken GenerateRefreshToken()
        {
            var refreshtoken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7)
            };
            return refreshtoken;
        }
        private void SetRefreshToken(RefreshToken newRefreshToken)
        {
            var CookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires,
            };
            Response.Cookies.Append("refreshtoken", newRefreshToken.Token, CookieOptions);

            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}