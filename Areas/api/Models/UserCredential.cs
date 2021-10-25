using System.ComponentModel.DataAnnotations;

namespace PixelPlusMulakat.Areas.api.Models
{
    public class UserCredential
    {
        [Required(ErrorMessage = "*Email Alanı Boş Geçilemez.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Geçerli Email adresi giriniz.")]
        [MaxLength(50, ErrorMessage = "Kategori Adı 50 Karakterden Uzun Olamaz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*Şifre Alanı Boş Geçilemez.")]
        [MaxLength(200, ErrorMessage = "Kullanıcı Parolası 200 Karakterden Uzun Olamaz")]
        public string Password { get; set; }
    }
}