﻿using Microsoft.AspNetCore.Mvc;
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
        private SetMananger setMananger;
        private UserManager userManager;

        public PackController(TCG_CollectionGameContext context)
        {
            cardManager = new CardManager(context);
            setMananger = new SetMananger(context);
            userManager = new UserManager(context);
        }

        public IActionResult Index()
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }
            ViewBag.user = userManager.GetUser(TempData.Peek("username").ToString());
            ViewData["sets"] = getSets();
            return View();
        }

        public async Task<IActionResult> OpenAsync(string Code)
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }

            ViewBag.user = userManager.GetUser(TempData.Peek("username").ToString());
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
                            cardManager.AddCard(new Pokecard(int.Parse(TempData.Peek("userID").ToString()), code, PokeCardsId[i], PokeCardsImg[i]));
                        }
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
            List<Pokeset> sets = setMananger.GetSets();

            return sets;
        }

        public bool cheokCoins()
        {
            User u = userManager.GetUser(TempData.Peek("username").ToString());

            if (u.Coin !>= 25)
            {
                u.Coin = u.Coin - 25;
                userManager.UpdateUser(u);
                return true;
            }
            return false;
        }
    }
}