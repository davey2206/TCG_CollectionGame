namespace TCG_CollectionGame.Entities.Models
{
    public class Trade
    {
        public int ID { get; set; }
        public User User1 { get; set; }
        public User User2 { get; set; }
        public Pokecard Card1 { get; set; }
        public Pokecard Card2 { get; set; }
    }
}
