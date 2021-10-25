using System;
using System.ComponentModel.DataAnnotations;

namespace PixelPlusMulakat.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "*Makale Başlığı Boş Bırakılamaz")]
        [MaxLength(150, ErrorMessage = "Makale Başlığı 150 Karakterden Uzun Olamaz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "*Makale İçeriği Boş Bırakılamaz")]
        public string Content { get; set; }
        [Required(ErrorMessage = "*Makale Oluşturma Tarihi Boş Bırakılamaz")]
        public DateTime CreatedDate { get; set; }
        [Required(ErrorMessage = "*Makale Kategorisi Boş Bırakılamaz")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "*Makale Oluşturan Kişi Boş Bırakılamaz")]
        public int CreatorId { get; set; }
        [Required(ErrorMessage = "*Makale Durumu Boş Bırakılamaz")]
        public int StatusId { get; set; }
    }
}