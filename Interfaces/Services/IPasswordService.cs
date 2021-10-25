namespace PixelPlusMulakat.Interfaces.Services
{
    public interface IPasswordService
    {
        bool ByteArraysEqual(byte[] b1, byte[] b2);
        string HashPassword(string password);
        bool isVerifyHashedPassword(string hashedPasword, string password);
    }
}