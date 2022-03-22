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
        private CardManager cardManager;

        public PackController(TCG_CollectionGameContext context)
        {
            cardManager = new CardManager(context);
            
        }

        public async Task<IActionResult> IndexAsync()
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }

            ViewData["sets"] = await getSetsAsync();
            return View();
        }

        public async Task<IActionResult> OpenAsync(string sName)
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }

            ViewData["cards"] = await getCardsAsync(sName);
            ViewData["sets"] = await getSetsAsync();
            return View();
        }

        public async Task<List<string>> getCardsAsync(string sName)
        {
            var sets = await Sets.AllAsync();
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
            var cards = await Card.GetAsync(query);
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

                var card = await Card.FindAsync<Pokemon>(pokecard);
                PokeCardsImg.Add(card.Card.ImageUrl);
            }

            return PokeCardsImg;
        }

        public async Task<List<string>> getSetsAsync()
        {
            List<string> lSets = new List<string>();
            try
            {
                var sets = await Sets.AllAsync();
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
