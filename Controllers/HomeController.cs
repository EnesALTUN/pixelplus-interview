using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PixelPlusMulakat.Interfaces.Repositories;
using PixelPlusMulakat.Interfaces.Services;
using PixelPlusMulakat.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace PixelPlusMulakat.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _env;
        private readonly IGenericRepository<Article> _articleRepository;
        private readonly IArticleService _articleService;

        public HomeController(IHostingEnvironment env, IGenericRepository<Article> articleRepository, IArticleService articleService)
        {
            _env = env;
            _articleRepository = articleRepository;
            _articleService = articleService;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<Article> articles = _articleRepository.GetAll();

            return View(_articleService.ArticleDetails(articles, 400));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload.Length <= 0) return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();


            var path = Path.Combine(_env.WebRootPath, "Uploads/images", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);
            }

            var url = $"{"/Uploads/images/"}{fileName}";

            return Json(new { uploaded = true, url });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}