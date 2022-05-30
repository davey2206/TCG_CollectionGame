using System;
using System.Collections.Generic;
using System.Text;
using TCG_CollectionGame.Business.Interfaces;
using TCG_CollectionGame.Data.Interfaces;
using TCG_CollectionGame.Entities.Models;

namespace TCG_CollectionGame.Business.Services
{
    public class BusinessTradeService : IBusinessTradeService
    {
        private readonly IDataTradeService _tradeService;
        public BusinessTradeService(IDataTradeService tradeService)
        {
            _tradeService = tradeService;
        }

        public void AddTrade(User user1, User user2, Pokecard card1, Pokecard card2)
        {
            Trade trade = new Trade { User1 = user1, User2 = user2, Card1 = card1, Card2 = card2};
            _tradeService.AddTrade(trade);
        }

        public void DeleteTrade(int id)
        {
            throw new NotImplementedException();
        }

        public List<Trade> GetAllTrades(User user)
        {
            return _tradeService.GetAllTrades(user);
        }

        public Trade GetTrade(int id)
        {
            throw new NotImplementedException();
        }
    }
}
