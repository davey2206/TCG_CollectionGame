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
        private  CardManager cardManager;

        public CollectionController(TCG_CollectionGameContext context)
        {
            cardManager = new CardManager(context);
        }

        public async Task<IActionResult> Index()
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }
            ViewData["sets"] = await getSetsAsync();
            return View();
        }

        public async Task<IActionResult> CollectionAsync(string sName)
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }
            ViewData["sets"] = await getSetsAsync();
            ViewData["cards"] = await getCardsAsync(sName);
            return View();
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

        public async Task<List<string>> getCardsAsync(string sName)
        {
            List<string> lCards = new List<string>();
            try
            {
                var sets = await Sets.AllAsync();
                string code = null;
                foreach (var set in sets)
                {
                    if (set.Name == sName)
                    {
                        code = set.Code;
                    }
                }
                List<string> cards = cardManager.getCards(code, int.Parse(TempData.Peek("userID").ToString()));
                foreach (var card in cards)
                {
                    var pokeCard = await Card.FindAsync<Pokemon>(card);
                    lCards.Add(pokeCard.Card.ImageUrl);
                }
            }
            catch (Exception)
            {

            }
            return lCards;
        }
    }
}
