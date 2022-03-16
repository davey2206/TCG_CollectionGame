using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonTcgSdk;

namespace TCG_CollectionGame.Controllers
{
    public class CollectionController : Controller
    {
        public IActionResult Index()
        {
            if (TempData.Peek("userID") == null)
            {
                return RedirectToAction("index", "Login");
            }
            ViewData["sets"] = getSets();
            return View();
        }

        public IActionResult Collection(string sName)
        {
            if (TempData.Peek("userID") == null)
            {
                return RedirectToAction("index", "Login");
            }
            ViewData["sets"] = getSets();
            ViewData["cards"] = getCards(sName);
            return View();
        }

        public List<string> getSets()
        {
            List<string> lSets = new List<string>();
            try
            {
                var sets = Sets.All();
                sets = Sets.All();
                foreach (var set in sets)
                {
                    lSets.Add(set.Name);
                }
            }
            catch (Exception)
            {

            }
            

            return lSets;
        }

        public List<string> getCards(string sName)
        {
            List<string> lCards = new List<string>();
            try
            {
                var sets = Sets.All();
                string code = null;
                foreach (var set in sets)
                {
                    if (set.Name == sName)
                    {
                        code = set.Code;
                    }
                }
                Dictionary<string, string> query = new Dictionary<string, string>()
                {
                    { "setCode", code }
                };
                var cards = Card.Get(query);
                foreach (var card in cards.Cards)
                {
                    lCards.Add(card.ImageUrl);
                }
            }
            catch (Exception)
            {

            }


            return lCards;
        }
    }
}
