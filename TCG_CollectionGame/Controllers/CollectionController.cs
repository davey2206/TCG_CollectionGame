using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TCG_CollectionGame.Business.Interfaces;
using TCG_CollectionGame.Enities.Models;
using TCG_CollectionGame.Models;

namespace TCG_CollectionGame.Controllers
{
    public class CollectionController : Controller
    {
        private readonly IBusinessSetService _setService;
        private readonly IBusinessCardService _cardService;
        private readonly IBusinessUserService _userService;
        public CollectionController(IBusinessSetService setService, IBusinessCardService cardService, IBusinessUserService userService)
        {
            _setService = setService;
            _cardService = cardService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }
            ViewData["sets"] = _setService.GetAllSets();
            return View();
        }

        public IActionResult Collection(string code)
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }
            ViewData["sets"] = _setService.GetAllSets();
            ViewData["cards"] = _cardService.GetAllCards(_userService.GetUser(TempData.Peek("username").ToString()), code);
            return View();
        }
    }
}