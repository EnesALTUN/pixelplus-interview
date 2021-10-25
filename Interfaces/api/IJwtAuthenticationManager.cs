namespace PixelPlusMulakat.Interfaces.api
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string email, string password);
    }
}