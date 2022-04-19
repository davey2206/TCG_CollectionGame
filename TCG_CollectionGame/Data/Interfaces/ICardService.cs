using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCG_CollectionGame.Models;

namespace TCG_CollectionGame.Data.Interfaces
{
    public interface ICardService
    {
        List<string> GetCards(string setCode, int userId);

        void AddCard(Pokecard pokecard);
    }
}