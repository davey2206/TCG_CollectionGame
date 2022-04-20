using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TCG_CollectionGame.Data.Interfaces;
using TCG_CollectionGame.Models;

namespace TCG_CollectionGame.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICardService _cardService;
        private readonly ISetService _setService;

        public CollectionController(ICardService cardService, ISetService setService)
        {
            _cardService = cardService;
            _setService = setService;
        }

        public IActionResult Index()
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }
            ViewData["sets"] = getSets();
            return View();
        }

        public IActionResult Collection(string Code)
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }
            ViewData["sets"] = getSets();
            ViewData["cards"] = getCards(Code);
            return View();
        }

        public List<Pokeset> getSets()
        {
            List<Pokeset> sets = _setService.GetSets();

            return sets;
        }

        public List<string> getCards(string code)
        {
            List<string> lCards = new List<string>();
            try
            {
                List<string> cards = _cardService.GetCards(code, int.Parse(TempData.Peek("userID").ToString()));
                foreach (var card in cards)
                {
                    lCards.Add(card);
                }
            }
            catch (Exception)
            {
            }
            return lCards;
        }
    }
}