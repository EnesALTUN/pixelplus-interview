using Microsoft.AspNetCore.Authentication.Cookies;
using PixelPlusMulakat.Interfaces.Repositories;
using PixelPlusMulakat.Interfaces.Services;
using PixelPlusMulakat.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace PixelPlusMulakat.Services
{
    public class LoginService : ILoginService
    {
        private readonly IGenericRepository<Users> _userRepository;
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly IPasswordService _passwordService;
        public LoginService(IGenericRepository<Users> userRepository, IGenericRepository<Role> roleRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _passwordService = passwordService;
        }

        public ClaimsPrincipal Login(string email, string password)
        {
            try
            {
                Users user = _userRepository.GetByCriteria(
                    filter => filter.Email.Contains(email)
                );

                if (user != null)
                {
                    Role userRole = _roleRepository.GetById(user.RolId);

                    if (_passwordService.isVerifyHashedPassword(user.Password, password))
                    {
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Surname, user.SurName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, userRole.Name)
                    };
                        var useridentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);

                        return principal;
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
    }
}