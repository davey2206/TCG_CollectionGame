using System.Collections.Generic;

namespace TCG_CollectionGame.Enities.Models
{
    public class Pokeset
    {
        public int ID { get; set; }
        public string SetCode { get; set; }
        public string SetName { get; set; }
        public ICollection<Pokecard> Cards { get; set; }
    }
}