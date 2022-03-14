using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCG_CollectionGame.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Coin { get; set; }
    }
}
