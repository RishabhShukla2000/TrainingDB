using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrainingDB.Custom_Model;
using TrainingDB.Models;
namespace TrainingDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly TrainingDBContext _context;

        public TokenController(IConfiguration config, TrainingDBContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomUser1 _userData)
        {
            if (_userData != null && _userData.Login != null  && _userData.Pword != null)
            {
                var user = await GetUser( _userData.Login, _userData.Pword);
                if (user != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                       

                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    JWTToken model = new JWTToken();
                    model.Token = new JwtSecurityTokenHandler().WriteToken(token);
                    model.UserName = user.UserName;
                    model.UserId = user.UserId;
                    model.RoleName = user.Role.RoleName;
                    model.ProfilePic = user.ProfilePic;
                    return Ok(model);
                }

                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private object TokenHandler()
        {
            throw new NotImplementedException();
        }

        private async Task<User> GetUser(string login, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => (u.Email == login || u.MobileNo == login) && u.Pword == password);
        }

    }
}
