using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
