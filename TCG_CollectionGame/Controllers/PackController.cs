using Microsoft.AspNetCore.Mvc;
using PokemonTcgSdk;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCG_CollectionGame.Business.Interfaces;
using TCG_CollectionGame.Enities.Models;
using TCG_CollectionGame.Models;

namespace TCG_CollectionGame.Controllers
{
    public class PackController : Controller
    {
        private readonly IBusinessSetService _setService;
        private readonly IBusinessCardService _cardService;
        private readonly IBusinessUserService _userService;
        public PackController(IBusinessSetService setService, IBusinessCardService cardService, IBusinessUserService userService)
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
            ViewBag.user = _userService.GetUser(TempData.Peek("username").ToString());
            ViewData["sets"] = _setService.GetAllSets();
            return View();
        }

        public IActionResult Open(string code)
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }

            List<string> cards = new List<string>();
            User user = _userService.GetUser(TempData.Peek("username").ToString());
            if (_userService.CheckCoins(TempData.Peek("username").ToString()))
            {
                cards = _cardService.AddCards(user, code);
                if (cards.Count != 0)
                {
                    User u = _userService.GetUser(TempData.Peek("username").ToString());
                    u.Coin = u.Coin - 25;
                    _userService.UpdateUser(u);
                }
            }

            ViewBag.user = user;
            ViewData["cards"] = cards;
            ViewData["sets"] = _setService.GetAllSets();
            return View();
        }
    }
}