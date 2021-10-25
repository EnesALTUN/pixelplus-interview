using PixelPlusMulakat.Interfaces.Services;

namespace PixelPlusMulakat.Services
{
    public class HelperService : IHelperService
    {
        public string ShortenText(string text, int length)
        {
            return text.Length > length ? string.Format("{0}...", text.Substring(0, length)) : text;
        }
    }
}