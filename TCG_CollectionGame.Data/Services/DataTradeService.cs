using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCG_CollectionGame.Data.Interfaces;
using TCG_CollectionGame.DataContext;
using TCG_CollectionGame.Entities.Models;

namespace TCG_CollectionGame.Data.Services
{
    public class DataTradeService : IDataTradeService
    {
        private readonly TCG_CollectionGameContext _context;

        public DataTradeService(TCG_CollectionGameContext context)
        {
            _context = context;
        }
        public void AddTrade(Trade trade)
        {
            _context.Database.ExecuteSqlRaw("INSERT INTO [Trade] VALUES ({0}, {1}, {2}, {3})", trade.User1.ID, trade.User2.ID, trade.Card1.ID, trade.Card2.ID);
        }

        public void DeleteTrade(int id)
        {
            _context.Database.ExecuteSqlRaw("DELETE FROM [Trade] WHERE ID = {0}", id);
        }

        public List<Trade> GetAllTrades(User user)
        {
            _context.User.Load();
            _context.Pokecard.Load();
            return _context.Trade.FromSqlRaw("SELECT * FROM [Trade] WHERE User2ID = {0}", user.ID).ToList();
        }

        public Trade GetTrade(int id)
        {
            _context.User.Load();
            _context.Pokecard.Load();
            return _context.Trade.FromSqlRaw("SELECT * FROM [Trade] WHERE ID = {0}", id).First();
        }
    }
}
