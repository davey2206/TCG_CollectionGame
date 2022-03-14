using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCG_CollectionGame.Models
{
    public class Pokecard
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string SetCode { get; set; }
        public string CardCode { get; set; }
    }
}
