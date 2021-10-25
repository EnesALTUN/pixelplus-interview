using PixelPlusMulakat.Areas.Admin.Models.ViewModels;
using PixelPlusMulakat.Models;
using System.Collections.Generic;

namespace PixelPlusMulakat.Interfaces.Services
{
    public interface IArticleService
    {
        ArticleVM ArticleDetails(int? id);
        List<ArticleVM> ArticleDetails(List<Article> articles, int length);
        ArticleCreateVM Create();
        bool Insert(Article article, string userEmail);
        ArticleCreateVM Update(Article article);
    }
}