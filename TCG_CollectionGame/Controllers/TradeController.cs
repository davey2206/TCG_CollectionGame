using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCG_CollectionGame.Controllers
{
    public class TradeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Incoming()
        {
            return View();
        }
    }
}
