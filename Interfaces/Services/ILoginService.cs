using System.Security.Claims;

namespace PixelPlusMulakat.Interfaces.Services
{
    public interface ILoginService
    {
        ClaimsPrincipal Login(string email, string password);
    }
}