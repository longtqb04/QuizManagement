using Microsoft.AspNetCore.Mvc;

namespace QuizManagement.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {

            return View();
        }

        public IActionResult Register()
        {

            return View();
        }

    }
}
