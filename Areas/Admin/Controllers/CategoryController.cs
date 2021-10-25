using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PixelPlusMulakat.Interfaces.Repositories;
using PixelPlusMulakat.Models;

namespace PixelPlusMulakat.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class CategoryController : Controller
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        public CategoryController(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        
        public IActionResult Index()
        {
            return View(_categoryRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoryRepository.Insert(category);
                    _categoryRepository.Save();

                    TempData["Success"] = "Kategori Ekleme İşlemi Başarılı";
                }
                catch
                {
                    TempData["Error"] = "Kategori Ekleme İşlemi Başarısız";
                }
            }
            else
                TempData["Error"] = "Kategori Ekleme İşlemi Başarısız";

            return RedirectToAction("Index", "Category");
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Category");

            return View(_categoryRepository.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoryRepository.Update(category);
                    _categoryRepository.Save();

                    TempData["Success"] = "Kategori Düzenleme İşlemi Başarılı";
                }
                catch
                {
                    TempData["Error"] = "Kategori Düzenleme İşlemi Başarısız";
                }
            }
            else
                TempData["Error"] = "Kategori Düzenleme İşlemi Başarısız";

            return RedirectToAction("Index", "Category");
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                try
                {
                    _categoryRepository.Delete(id);
                    _categoryRepository.Save();

                    TempData["Success"] = "Kategori Silme İşlemi Başarılı";
                }
                catch
                {
                    TempData["Error"] = "Kategori Silme İşlemi Başarısız";
                }
            }
            else
                TempData["Error"] = "Kategori Silme İşlemi Başarısız";

            return RedirectToAction("Index", "Category");
        }
    }
}