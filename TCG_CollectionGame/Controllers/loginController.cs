using Microsoft.AspNetCore.Mvc;

namespace TCG_CollectionGame.Controllers
{
    public class loginController : Controller
    {
        public IActionResult Index()
        {
            var errMsg = TempData["ErrorMessage"] as string;
            ViewData["Msg"] = errMsg;
            return View();
        }

        public IActionResult Register()
        {
            var errMsg = TempData["ErrorMessage"] as string;
            ViewData["Msg"] = errMsg;
            return View();
        }
    }
}