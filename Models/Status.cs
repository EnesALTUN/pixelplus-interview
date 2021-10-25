using System.ComponentModel.DataAnnotations;

namespace PixelPlusMulakat.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "*Durum Adı Boş Bırakılamaz")]
        [MaxLength(20, ErrorMessage = "Durum Adı 20 Karakterden Uzun Olamaz")]
        public string Name { get; set; }
    }
}