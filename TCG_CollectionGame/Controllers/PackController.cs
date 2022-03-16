using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonTcgSdk;
using TCG_CollectionGame.Models;

namespace TCG_CollectionGame.Controllers
{
    public class PackController : Controller
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

        public IActionResult Open(string sName)
        {
            if (TempData.Peek("userID") == null)
            {
                return RedirectToAction("index", "Login");
            }

            ViewData["cards"] = getCommon(sName);
            ViewData["sets"] = getSets();
            return View();
        }

        public List<string> getCommon(string sName)
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
            List<string> pokecards = new List<string>();
            Dictionary<string, string> query = new Dictionary<string, string>()
            {
                { "setCode", code },
                { "rarity", "Common" }
            };
            var cards = Card.Get(query);
            foreach (var card in cards.Cards)
            {
                pokecards.Add(card.ImageUrl);
            }
            return pokecards;
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
    }
}
