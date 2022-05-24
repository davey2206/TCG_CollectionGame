using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TCG_CollectionGame.Enities.Models;

namespace TCG_CollectionGame.Business.Interfaces
{
    public interface IBusinessCardService
    {
        public List<string> GetAllCards(User user, string code);
        public List<string> AddCards(User user, string code);
    }
}
