using System.Collections.Generic;

namespace TCG_CollectionGame.Entities.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Coin { get; set; }
        public ICollection<Pokecard> Cards { get; set; }
    }
}