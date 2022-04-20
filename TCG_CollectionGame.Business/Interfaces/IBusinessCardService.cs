using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TCG_CollectionGame.Business.Interfaces
{
    public interface IBusinessCardService
    {
        public List<string> GetAllCards(int id, string code);
        public List<string> AddCards(int userId, string code);
    }
}
