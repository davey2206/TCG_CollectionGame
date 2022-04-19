using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonTcgSdk;
using TCG_CollectionGame.Models;
using TCG_CollectionGame.Data;

namespace TCG_CollectionGame.Controllers
{
    public class CollectionController : Controller
    {
        private CardManager cardManager;
        private SetManager setManager;

        public CollectionController(TCG_CollectionGameContext context)
        {
            cardManager = new CardManager(context);
            setManager = new SetManager(context);
        }

        public async Task<IActionResult> Index()
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
            List<Pokeset> sets = setManager.getSets();

            return sets;
        }

        public List<string> getCards(string code)
        {
            List<string> lCards = new List<string>();
            try
            {
                List<string> cards = cardManager.GetCards(code, int.Parse(TempData.Peek("userID").ToString()));
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