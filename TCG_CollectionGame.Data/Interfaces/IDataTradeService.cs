using System;
using System.Collections.Generic;
using System.Text;
using TCG_CollectionGame.Entities.Models;

namespace TCG_CollectionGame.Data.Interfaces
{
    public interface IDataTradeService
    {
        void AddTrade(Trade trade);
        void DeleteTrade(int id);
        List<Trade> GetAllTrades(User user);
        Trade GetTrade(int id);
    }
}
