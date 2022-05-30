using System.Collections.Generic;
using TCG_CollectionGame.Entities.Models;

namespace TCG_CollectionGame.Data.Interfaces
{
    public interface IDataCardService
    {
        List<string> GetCards(string code, User user);
        List<Pokecard> GetAllCards(User user);
        void AddCard(Pokecard pokecard);
        Pokecard GetCards(int cardID);
        void updateCard(Pokecard card1, Pokecard card2);
    }
}