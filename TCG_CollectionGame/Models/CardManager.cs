using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCG_CollectionGame.Data;

namespace TCG_CollectionGame.Models
{
    public class CardManager
    {
        private readonly TCG_CollectionGameContext _context;

        public CardManager(TCG_CollectionGameContext context)
        {
            _context = context;
        }

        public void AddCard(Pokecard pokecard)
        {
            _context.Pokecard.Add(pokecard);
            _context.SaveChanges();
        }

        public List<string> getCards(string setCode, int userId)
        {
            List<string> cardIds = new List<string>();
            var cards = _context.Pokecard.Where(e => e.SetCode == setCode && e.UserId == userId);
            foreach (var card in cards)
            {
                cardIds.Add(card.CardImg);
            }
            return cardIds;
        }
    }
}
