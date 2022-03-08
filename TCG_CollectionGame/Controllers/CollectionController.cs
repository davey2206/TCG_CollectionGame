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
            ViewData["sets"] = getSets();
            return View();
        }

        public IActionResult Collection(string sName)
        {
            ViewData["sets"] = getSets();
            ViewData["cards"] = getCards(sName);
            return View();
        }

        public List<string> getSets()
        {
            var sets = Sets.All();
            while (sets == null || sets.Count == 0)
            {
                sets = Sets.All();
            }
            List<string> lSets = new List<string>();
            foreach (var set in sets)
            {
                lSets.Add(set.Name);
            }

            return lSets;
        }

        public List<string> getCards(string sName)
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
            List<string> lCards = new List<string>();
            foreach (var card in cards.Cards)
            {
                lCards.Add(card.ImageUrl);
            }

            return lCards;
        }
    }
}
