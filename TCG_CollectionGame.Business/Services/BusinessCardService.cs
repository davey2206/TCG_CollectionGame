using PokemonTcgSdk;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TCG_CollectionGame.Business.Interfaces;
using TCG_CollectionGame.Data.Interfaces;
using TCG_CollectionGame.Enities.Models;

namespace TCG_CollectionGame.Business.Services
{
    public class BusinessCardService : IBusinessCardService
    {
        private readonly IDataCardService _cardService;
        public BusinessCardService(IDataCardService cardService)
        {
            _cardService = cardService;
        }

        public List<string> GetAllCards(User user, string code)
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
                        _cardService.AddCard(new Pokecard(user, code, PokeCardsId[i], PokeCardsImg[i]));
                    }
                }
            }
            catch (Exception)
            {
            }
            return PokeCardsImg;
        }
    }
}
