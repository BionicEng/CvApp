using CvApp.Business.Services.Abstract;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Business.Services.Concrete
{
    public class AuthService : IAuthManager
    {
        private readonly IRepositoryManager<UserEntity> _userRepository;
        private readonly ILogger<AuthService> _logger;
        private readonly IConfiguration _configuration;

        public AuthService(IRepositoryManager<UserEntity> userRepository, ILogger<AuthService> logger, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _logger = logger;
            _configuration = configuration;
        }
        public string? GenerateToken(string email, string password)
        {
            var user = _userRepository.Get().FirstOrDefault(x => x.Password == password && x.Email == email);
            if (user == null)
            {
                _logger.LogError("Email adresi veya şifresi hatalı olan giriş denendi.");
                return null;
            }
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var jwtKey = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                _logger.LogError("appsettings.json'da Jwt Key'e ulaşılamadı.");
                return null;
            }
            var keyBytes = Encoding.ASCII.GetBytes(jwtKey);
            var key = new SymmetricSecurityKey(keyBytes);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                Expires = DateTime.UtcNow.AddMinutes(15),
                Subject = new ClaimsIdentity(new[] {
                    new Claim(JwtRegisteredClaimNames.Name, user.FirstName),
                    new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sid, user.UserId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Gender, user.Gender),
                    new Claim(ClaimTypes.Country,user.Location),

                }
                ),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
            };
            user.Roles.Split(',', StringSplitOptions.TrimEntries).ToList().ForEach(role =>
            {
                tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role));
            });
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;

        }
    }
}
