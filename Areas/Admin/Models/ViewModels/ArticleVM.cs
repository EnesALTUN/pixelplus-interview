using PixelPlusMulakat.Models;
using System.Collections.Generic;

namespace PixelPlusMulakat.Areas.Admin.Models.ViewModels
{
    public class ArticleVM
    {
        public Article Article { get; set; }
        public string CategoryName { get; set; }
        public Users Creator { get; set; }
        public string Status { get; set; }
    }
}