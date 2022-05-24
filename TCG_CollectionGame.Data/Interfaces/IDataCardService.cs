using System.Collections.Generic;
using TCG_CollectionGame.Enities.Models;

namespace TCG_CollectionGame.Data.Interfaces
{
    public interface IDataCardService
    {
        List<string> GetCards(string code, User user);

        void AddCard(Pokecard pokecard);
    }
}