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
    public class PackController : Controller
    {
        private readonly TCG_CollectionGameContext _context;
        private CardManager cardManager;

        public PackController(TCG_CollectionGameContext context)
        {
            _context = context;
            cardManager = new CardManager(context);
            
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

        public IActionResult Open(string sName)
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }

            ViewData["cards"] = getCards(sName);
            ViewData["sets"] = getSets();
            return View();
        }

        public List<string> getCards(string sName)
        {
            var sets = Sets.All();
            string code = null;
            List<string> AllPokeCards = new List<string>();
            List<string> PokeCardsId = new List<string>();
            List<string> PokeCardsImg = new List<string>();
            Random rng = new Random();

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
                AllPokeCards.Add(card.Id);
            }

            for (int i = 0; i < 5; i++)
            {
                int index = rng.Next(AllPokeCards.Count);
                PokeCardsId.Add(AllPokeCards[index]);
            }

            foreach (var pokecard in PokeCardsId)
            {
                cardManager.AddCard(new Pokecard(int.Parse(TempData.Peek("userID").ToString()), code, pokecard));

                var card = Card.Find<Pokemon>(pokecard);
                PokeCardsImg.Add(card.Card.ImageUrl);
            }

            return PokeCardsImg;
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
