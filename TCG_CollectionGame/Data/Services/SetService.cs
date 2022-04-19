using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCG_CollectionGame.Data.Interfaces;
using TCG_CollectionGame.Models;

namespace TCG_CollectionGame.Data.Services
{
    public class SetService : ISetService
    {
        private readonly TCG_CollectionGameContext _context;

        public SetService(TCG_CollectionGameContext context)
        {
            _context = context;
        }

        public List<Pokeset> GetSets()
        {
            List<Pokeset> sets = new List<Pokeset>();
            sets = _context.Pokeset.ToList();

            return sets;
        }
    }
}