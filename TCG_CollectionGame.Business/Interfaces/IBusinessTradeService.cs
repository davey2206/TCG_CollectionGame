using System;
using System.Collections.Generic;
using System.Text;
using TCG_CollectionGame.Entities.Models;

namespace TCG_CollectionGame.Business.Interfaces
{
    public interface IBusinessTradeService
    {
        void AddTrade(User user1, User user2, Pokecard card1, Pokecard card2);
        void DeleteTrade(int id);
        List<Trade> GetAllTrades(User user);
        Trade GetTrade(int id);
    }
}
