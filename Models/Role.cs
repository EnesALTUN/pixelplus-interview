using System.ComponentModel.DataAnnotations;

namespace PixelPlusMulakat.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*Rol Adı Boş Bırakılamaz")]
        [MaxLength(50, ErrorMessage = "Rol Adı 50 Karakterden Uzun Olamaz")]
        public string Name { get; set; }
    }
}
