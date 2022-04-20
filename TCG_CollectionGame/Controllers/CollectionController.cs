using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TCG_CollectionGame.Business.Interfaces;
using TCG_CollectionGame.Models;

namespace TCG_CollectionGame.Controllers
{
    public class CollectionController : Controller
    {
        private readonly IBusinessSetService _setService;
        private readonly IBusinessCardService _cardService;
        public CollectionController(IBusinessSetService setService, IBusinessCardService cardService)
        {
            _setService = setService;
            _cardService = cardService;
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

        public IActionResult Collection(string Code)
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }
            ViewData["sets"] = _setService.GetAllSets();
            ViewData["cards"] = _cardService.GetAllCards(int.Parse(TempData.Peek("userID").ToString()), Code);
            return View();
        }
    }
}