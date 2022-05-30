using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCG_CollectionGame.Business.Interfaces;
using TCG_CollectionGame.Entities.Models;

namespace TCG_CollectionGame.Controllers
{
    public class TradeController : Controller
    {
        private readonly IBusinessUserService _userService;
        private readonly IBusinessCardService _cardService;
        private readonly IBusinessTradeService _tradeService;

        public TradeController(IBusinessUserService userService, IBusinessCardService cardService, IBusinessTradeService tradeService)
        {
            _userService = userService;
            _cardService = cardService;
            _tradeService = tradeService;
        }
        public IActionResult Index()
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }

            ViewData["cards"] = _cardService.GetAllCards(_userService.GetUser(TempData.Peek("username").ToString()));
            ViewData["users"] = _userService.GetAllUsers(TempData.Peek("username").ToString());
            return View();
        }
        public IActionResult Trade(string username)
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }

            ViewData["cards"] = _cardService.GetAllCards(_userService.GetUser(TempData.Peek("username").ToString()));
            ViewData["cards2"] = _cardService.GetAllCards(_userService.GetUser(username));
            ViewData["users"] = _userService.GetAllUsers(TempData.Peek("username").ToString());
            ViewData["user"] = username;
            return View();
        }
        [HttpPost]
        public IActionResult Trade(int Card1, int Card2, string Username)
        {
            string Log_Username = TempData.Peek("username").ToString();
            User user1 = _userService.GetUser(Log_Username);
            User user2 = _userService.GetUser(Username);
            Pokecard card1 = _cardService.GetCards(Card1);
            Pokecard card2 = _cardService.GetCards(Card2);

            _tradeService.AddTrade(user1, user2, card1, card2);


            return RedirectToAction("Trade", "Trade", new { username = Username });
        }

        public IActionResult Incoming()
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }

            ViewData["trades"] = _tradeService.GetAllTrades(_userService.GetUser(TempData.Peek("username").ToString()));
            return View();
        }
        [HttpPost]
        public IActionResult Accept(int id)
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }

            Trade trade = _tradeService.GetTrade(id);
            _cardService.updateCard(trade);
            _tradeService.DeleteTrade(id);

            return RedirectToAction("Incoming" , "Trade");
        }
        [HttpPost]
        public IActionResult Reject(int id)
        {
            if (TempData.Peek("username") == null)
            {
                return RedirectToAction("index", "Login");
            }

            _tradeService.DeleteTrade(id);

            return RedirectToAction("Incoming", "Trade");
        }
    }
}
