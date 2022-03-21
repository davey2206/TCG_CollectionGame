using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCG_CollectionGame.Models
{
    public class Pokecard
    {
        public Pokecard(int userId, string setCode, string cardCode)
        {
            this.UserId = userId;
            this.SetCode = setCode;
            this.CardCode = cardCode;
        }

        public int ID { get; set; }
        public int UserId { get; set; }
        public string SetCode { get; set; }
        public string CardCode { get; set; }
    }
}
