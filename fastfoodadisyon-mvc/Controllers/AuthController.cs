using Microsoft.AspNetCore.Mvc;

namespace fastfoodadisyon_mvc.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult AuthPage()
        {
            return View("Page");
        }
    }
}
