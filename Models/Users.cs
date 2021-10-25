using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PixelPlusMulakat.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "*Kullanıcı Adı Boş Bırakılamaz")]
        [MaxLength(50, ErrorMessage = "Kullanıcı Adı 50 Karakterden Uzun Olamaz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*Kullanıcı Soyadı Boş Bırakılamaz")]
        [MaxLength(50, ErrorMessage = "Kategori Adı 50 Karakterden Uzun Olamaz")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "*Email Alanı Boş Geçilemez.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Geçerli Email adresi giriniz.")]
        [MaxLength(50, ErrorMessage = "Kategori Adı 50 Karakterden Uzun Olamaz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*Şifre Alanı Boş Geçilemez.")]
        [MaxLength(200, ErrorMessage = "Kategori Adı 200 Karakterden Uzun Olamaz")]
        public string Password { get; set; }
        [Required(ErrorMessage = "*Durum Boş Bırakılamaz")]
        public bool Status { get; set; }
        [Required(ErrorMessage = "*Kullanıcı Rol Alanı Boş Bırakılamaz")]
        public int RolId { get; set; }
    }
}