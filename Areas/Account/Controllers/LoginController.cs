using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PixelPlusMulakat.Interfaces.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PixelPlusMulakat.Areas.Account.Controllers
{
    [Area("Account")]
    [Route("[area]/[action]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password, string returnUrl = "/")
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                TempData["Err"] = "Gerekli bilgileri doldurunuz.";
            }
            else
            {
                ClaimsPrincipal principal = _loginService.Login(email, password);

                if (principal != null)
                    await HttpContext.SignInAsync(principal);
                else
                {
                    TempData["Err"] = "Giriş işlemi başarısız";
                    return View();
                }

                return Redirect(returnUrl);
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}