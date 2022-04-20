using Microsoft.AspNetCore.Mvc;
using PokemonTcgSdk;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCG_CollectionGame.Data.Interfaces;
using TCG_CollectionGame.Models;

namespace TCG_CollectionGame.Controllers
{
    public class PackController : Controller
    {
        private readonly ICardService _cardService;
        private readonly ISetService _setService;
        private readonly IUserService _userService;

        public PackController(ICardService cardService, ISetService setService, IUserService userService)
        {
            _cardService = cardService;
            _setService = setService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }
            ViewBag.user = _userService.GetUser(TempData.Peek("username").ToString());
            ViewData["sets"] = getSets();
            return View();
        }

        public async Task<IActionResult> OpenAsync(string Code)
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }

            ViewBag.user = _userService.GetUser(TempData.Peek("username").ToString());
            ViewData["cards"] = await getCardsAsync(Code);
            ViewData["sets"] = getSets();
            return View();
        }

        public async Task<List<string>> getCardsAsync(string code)
        {
            List<string> AllPokeCards = new List<string>();
            List<string> AllPokeCardsImg = new List<string>();
            List<string> PokeCardsImg = new List<string>();
            List<string> PokeCardsId = new List<string>();

            if (cheokCoins())
            {
                try
                {
                    Random rng = new Random();

                    Dictionary<string, string> query = new Dictionary<string, string>()
                    {
                        { "setCode", code }
                    };
                    var cards = await Card.GetAsync(query);
                    if (cards.Cards != null)
                    {
                        foreach (var card in cards.Cards)
                        {
                            AllPokeCards.Add(card.Id);
                            AllPokeCardsImg.Add(card.ImageUrl);
                        }

                        for (int i = 0; i < 5; i++)
                        {
                            int index = rng.Next(AllPokeCards.Count);
                            PokeCardsId.Add(AllPokeCards[index]);
                            PokeCardsImg.Add(AllPokeCardsImg[index]);
                        }

                        for (int i = 0; i < PokeCardsId.Count; i++)
                        {
                            _cardService.AddCard(new Pokecard(int.Parse(TempData.Peek("userID").ToString()), code, PokeCardsId[i], PokeCardsImg[i]));
                        }

                        User u = _userService.GetUser(TempData.Peek("username").ToString());
                        u.Coin = u.Coin - 25;
                        _userService.UpdateUser(u);
                    }
                }
                catch (Exception)
                {
                }
            }

            return PokeCardsImg;
        }

        public List<Pokeset> getSets()
        {
            List<Pokeset> sets = _setService.GetSets();

            return sets;
        }

        public bool cheokCoins()
        {
            User u = _userService.GetUser(TempData.Peek("username").ToString());

            if (u.Coin! >= 25)
            {
                return true;
            }
            return false;
        }
    }
}