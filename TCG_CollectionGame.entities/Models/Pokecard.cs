namespace TCG_CollectionGame.Enities.Models
{
    public class Pokecard
    {
        public Pokecard(User user, Pokeset pokeset, string cardCode, string cardImg)
        {
            this.User = user;
            this.Pokeset = pokeset;
            this.CardCode = cardCode;
            this.CardImg = cardImg;
        }
        public Pokecard() { }

        public int ID { get; set; }
        public string CardCode { get; set; }
        public string CardImg { get; set; }
        public User User { get; set; }
        public Pokeset Pokeset { get; set; }

    }
}