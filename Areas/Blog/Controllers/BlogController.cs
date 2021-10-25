using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PixelPlusMulakat.Areas.Admin.Models.ViewModels;
using PixelPlusMulakat.Interfaces.Services;

namespace PixelPlusMulakat.Areas.Blog.Controllers
{
    [Area("Blog")]
    [Route("[controller]/[action]")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        public BlogController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("{id}")]
        public IActionResult Detail(int? id)
        {
            if (id != null) { 
                ArticleVM articleVM = _articleService.ArticleDetails(id);

                if (articleVM != null)
                    return View(articleVM);
            }
            TempData["Error"] = "Ulaşmaya çalıştığınız blog bulunamadı.";

            return RedirectToAction("Index", "Home");
        }
    }
}
