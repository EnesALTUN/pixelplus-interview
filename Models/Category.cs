using System.ComponentModel.DataAnnotations;

namespace PixelPlusMulakat.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*Kategori Adı Boş Bırakılamaz")]
        [MaxLength(100, ErrorMessage = "Kategori Adı 100 Karakterden Uzun Olamaz")]
        public string Name { get; set; }
    }
}