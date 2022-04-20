using Microsoft.AspNetCore.Mvc;

namespace TCG_CollectionGame.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }
            return View();
        }
    }
}