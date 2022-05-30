using PokemonTcgSdk;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TCG_CollectionGame.Business.Interfaces;
using TCG_CollectionGame.Data.Interfaces;
using TCG_CollectionGame.Entities.Models;

namespace TCG_CollectionGame.Business.Services
{
    public class BusinessCardService : IBusinessCardService
    {
        private readonly IDataCardService _cardService;
        private readonly IDataSetService _setService;
        public BusinessCardService(IDataCardService cardService, IDataSetService setService)
        {
            _cardService = cardService;
            _setService = setService;
        }

        public List<string> GetCards(User user, string code)
        {
            return _cardService.GetCards(code, user);
        }
        public List<string> AddCards(User user, string code)
        {
            List<string> AllPokeCards = new List<string>();
            List<string> AllPokeCardsImg = new List<string>();
            List<string> PokeCardsImg = new List<string>();
            List<string> PokeCardsId = new List<string>();

            try
            {
                Random rng = new Random();

                Dictionary<string, string> query = new Dictionary<string, string>()
                 {
                    { "setCode", code }
                 };
                var cards = Card.Get(query);
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
                        _cardService.AddCard(new Pokecard(user, _setService.GetSet(code), PokeCardsId[i], PokeCardsImg[i]));
                    }
                }
            }
            catch (Exception)
            {
            }
            return PokeCardsImg;
        }

        public List<Pokecard> GetAllCards(User user)
        {
            return _cardService.GetAllCards(user);
        }

        public Pokecard GetCards(int cardID)
        {
            return _cardService.GetCards(cardID);
        }

        public void updateCard(Trade trade)
        {
            Pokecard card1 = trade.Card1;
            Pokecard card2 = trade.Card2;
            _cardService.updateCard(card1, card2);
        }
    }
}
