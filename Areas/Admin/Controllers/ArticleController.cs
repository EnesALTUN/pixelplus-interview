using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PixelPlusMulakat.Areas.Admin.Models.ViewModels;
using PixelPlusMulakat.Interfaces.Repositories;
using PixelPlusMulakat.Interfaces.Services;
using PixelPlusMulakat.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace PixelPlusMulakat.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class ArticleController : Controller
    {
        private readonly IGenericRepository<Article> _articleRepository;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IArticleService _articleService;
        public ArticleController(IGenericRepository<Article> articleRepository, IGenericRepository<Category> categoryRepository, IArticleService articleService)
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            List<Article> articles = _articleRepository.GetAll();

            return View(_articleService.ArticleDetails(articles, 150));
        }

        public IActionResult Create()
        {
            if (_categoryRepository.GetAll().Count == 0)
            {
                TempData["Error"] = "Makale eklenmesi için öncelikle kategori oluşturulmalıdır.";

                return RedirectToAction("Create", "Category");
            }

            return View(_articleService.Create());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArticleCreateVM articleCreateVM)
        {
            if (ModelState.IsValid)
            {
                if (_articleService.Insert(articleCreateVM.Article, User.FindFirst(ClaimTypes.Email).Value))
                    TempData["Success"] = "Makale Ekleme İşlemi Başarılı";
                else
                    TempData["Error"] = "Makale Ekleme İşlemi Başarısız";
            }
            else
                TempData["Error"] = "Makale Ekleme İşlemi Başarısız";

            return RedirectToAction("Index", "Article");
        }

        public IActionResult Update(int? id)
        {
            if(id != null)
            {
                return View(_articleService.Update(_articleRepository.GetById(id)));
            }
            else
            {
                TempData["Error"] = "Makale Düzenleme İşlemi Başarısız";

                return RedirectToAction("Index", "Article");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ArticleCreateVM articleCreateVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _articleRepository.Update(articleCreateVM.Article);
                    _articleRepository.Save();

                    TempData["Success"] = "Makale Düzenleme İşlemi Başarılı";
                }
                catch
                {
                    TempData["Error"] = "Makale Düzenleme İşlemi Başarısız";
                }
            }
            else
                TempData["Error"] = "Makale Düzenleme İşlemi Başarısız";

            return RedirectToAction("Index", "Article");
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                try
                {
                    _articleRepository.Delete(id);
                    _articleRepository.Save();

                    TempData["Success"] = "Makale Silme İşlemi Başarılı";
                }
                catch
                {
                    TempData["Error"] = "Makale Silme İşlemi Başarısız";
                }
            }
            else
                TempData["Error"] = "Makale Silme İşlemi Başarısız";

            return RedirectToAction("Index", "Article");
        }
    }
}