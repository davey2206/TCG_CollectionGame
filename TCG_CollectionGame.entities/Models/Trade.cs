using System;
using System.Collections.Generic;
using System.Text;
using TCG_CollectionGame.Enities.Models;

namespace TCG_CollectionGame.Entities.Models
{
    public class Trade
    {
        public User User1 { get; set; }
        public User User2 { get; set; }
        public Pokecard Card1 { get; set; }
        public Pokecard Card2 { get; set; }
    }
}
