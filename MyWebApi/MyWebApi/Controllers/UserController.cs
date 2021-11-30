using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyWebApi.Data;
using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly AppSetting _appSettings;
        public UserController(MyDbContext context, IOptionsMonitor<AppSetting> optionsMonitor)
        {
            _context = context;
            _appSettings = optionsMonitor.CurrentValue;
        }
        [HttpPost("Login")]
        public IActionResult Validate(LoginVm loginVm)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserName == loginVm.UserName && x.PassWord == loginVm.PassWord);
            if (user == null)
            {
                return Ok(new ApiReponse
                {
                    Success = false,
                    Message = "Invalid Username or Password"
                });
            }
            return Ok(new ApiReponse
            {
                Success = true,
                Message = "Authenticate Success",
                Data = GenerateToken(user).AccessToken
            });
        }
        private TokenModel GenerateToken(User user)
        {
            var jwtToken = new JwtSecurityTokenHandler();
            var secretKey = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.HoTen),
                    new Claim("UserName", user.UserName),
                    new Claim("UserId", user.Id.ToString()),
                    //role
                    new Claim("TokenId", Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey)
                ,SecurityAlgorithms.HmacSha256)
            };
            var token = jwtToken.CreateToken(tokenDescription);
            var accessToken = jwtToken.WriteToken(token);
            return new TokenModel
            {
                AccessToken = accessToken,
                RefreshToken = GenerateRefreshToken()

            };
        }

        private string GenerateRefreshToken()
        {
            return null;
        }
    }
}
