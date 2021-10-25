using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PixelPlusMulakat.Interfaces.api;
using PixelPlusMulakat.Interfaces.Repositories;
using PixelPlusMulakat.Interfaces.Services;
using PixelPlusMulakat.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PixelPlusMulakat.Services
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly IGenericRepository<Users> _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IConfiguration _configuration;
        public JwtAuthenticationManager(IGenericRepository<Users> userRepository, IPasswordService passwordService, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _configuration = configuration;
        }

        public string Authenticate(string email, string password)
        {
            Users user = _userRepository.GetByCriteria(
                filter => filter.Email.Contains(email)
            );

            if (user != null)
            {
                if (_passwordService.isVerifyHashedPassword(user.Password, password))
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenKey = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtSettings:Secret").Value);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Email, email)
                        }),
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials = new SigningCredentials(
                            new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    return tokenHandler.WriteToken(token);
                }
            }
            return null;
        }
    }
}
