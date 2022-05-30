using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TCG_CollectionGame.Entities.Models;

namespace TCG_CollectionGame.Business.Interfaces
{
    public interface IBusinessCardService
    {
        public List<string> GetCards(User user, string code);
        public List<Pokecard> GetAllCards(User user);
        public List<string> AddCards(User user, string code);
        public Pokecard GetCards(int cardID);
        public void updateCard(Trade trade);
    }
}
