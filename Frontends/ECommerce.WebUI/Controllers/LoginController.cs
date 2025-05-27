using ECommerce.WebUI.DTOs.IdentityDtos;
using ECommerce.WebUI.Services.IdentityServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class LoginController(IIdentityService _identityService, IHttpContextAccessor _contextAccessor) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignInDto signInDto)
        {
            var result = await _identityService.SignInAsync(signInDto);
            if (!result)
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                return View(signInDto);
            }

            var user = _contextAccessor.HttpContext.User.Claims;
            return RedirectToAction("Index", "Category");
        }

    }
}
