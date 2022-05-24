namespace TCG_CollectionGame.Enities.Models
{
    public class Pokecard
    {
        public Pokecard(User user, string setCode, string cardCode, string cardImg)
        {
            this.User = user;
            this.SetCode = setCode;
            this.CardCode = cardCode;
            this.CardImg = cardImg;
        }
        public Pokecard() { }

        public int ID { get; set; }
        public string SetCode { get; set; }
        public string CardCode { get; set; }
        public string CardImg { get; set; }
        public User User { get; set; }

    }
}