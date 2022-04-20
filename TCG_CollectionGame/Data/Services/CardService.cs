using System.Collections.Generic;
using System.Linq;
using TCG_CollectionGame.Data.Interfaces;
using TCG_CollectionGame.Models;

namespace TCG_CollectionGame.Data.Services
{
    public class CardService : ICardService
    {
        private readonly TCG_CollectionGameContext _context;

        public CardService(TCG_CollectionGameContext context)
        {
            _context = context;
        }

        public void AddCard(Pokecard pokecard)
        {
            _context.Pokecard.Add(pokecard);
            _context.SaveChanges();
        }

        public List<string> GetCards(string setCode, int userId)
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