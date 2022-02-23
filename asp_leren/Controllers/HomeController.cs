using asp_leren.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PokemonTcgSdk;

namespace asp_leren.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
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
            ViewData["sets"] = lSets;
            return View();
        }

        public IActionResult Collection(string sName)
        {
            var sets = Sets.All();
            while (sets == null || sets.Count == 0)
            {
                sets = Sets.All();
            }
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
            ViewData["cards"] = lCards;
            return View();
        }
    }
}