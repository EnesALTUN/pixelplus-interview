using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PixelPlusMulakat.Interfaces.Services;

namespace PixelPlusMulakat.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            return View(_adminService.GetContentCount());
        }
    }
}