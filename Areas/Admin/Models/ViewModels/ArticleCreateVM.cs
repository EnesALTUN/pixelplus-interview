using PixelPlusMulakat.Models;
using System.Collections.Generic;

namespace PixelPlusMulakat.Areas.Admin.Models.ViewModels
{
    public class ArticleCreateVM
    {
        public Article Article { get; set; }
        public List<Category> Categories { get; set; }
        public List<Status> Statuses { get; set; }
    }
}
