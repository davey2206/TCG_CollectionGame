using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCG_CollectionGame.Data;

namespace TCG_CollectionGame.Models
{
    public class SetMananger
    {
        private readonly TCG_CollectionGameContext _context;

        public SetMananger(TCG_CollectionGameContext context)
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