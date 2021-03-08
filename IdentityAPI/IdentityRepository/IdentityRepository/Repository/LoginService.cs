

using IdentityRepository.ContextFile;
using IdentityRepository.Interfaces;
using IdentityRepository.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace IdentityRepository.Repository
{
    public class LoginService: ILoginService
    {
        private readonly AppSettings _appSettings;
        private readonly IConfiguration _config;
        private readonly CustomerContext _dbContext;

        public LoginService(IConfiguration config, IOptions<AppSettings> appSettings, CustomerContext dbContext)
        {
            _config = config;
            _appSettings = appSettings.Value;
            _dbContext = dbContext;
        }

        public Login AuthenticateUser(Login login)
        {
            User user = GetUser(login);

            if (user == null)
                return null;

            Login response = new Login();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>(
                "AppSettings:SecretKey"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.UserRole),
                    new Claim(ClaimTypes.Version, "V1.0")
                }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            response.Token = tokenHandler.WriteToken(token);
            response.UserName = user.Email;
            response.UserId = user.Id;
            response.UserRole = user.UserRole;
            response.Password = null;
            return response;
        }

        private User GetUser(Login login)
        {
            return _dbContext.User.FirstOrDefault(x => x.Email == login.UserName && x.Password == login.Password);
        }
    }
}
