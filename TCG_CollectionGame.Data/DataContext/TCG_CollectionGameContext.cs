using Microsoft.EntityFrameworkCore;
using TCG_CollectionGame.Enities.Models;

namespace TCG_CollectionGame.DataContext
{
    public class TCG_CollectionGameContext : DbContext
    {
        public TCG_CollectionGameContext(DbContextOptions<TCG_CollectionGameContext> options)
            : base(options)
        {
        }

        public TCG_CollectionGameContext()
        {

        }

        public virtual DbSet<TCG_CollectionGame.Enities.Models.User> User { get; set; }
        public virtual DbSet<TCG_CollectionGame.Enities.Models.Pokecard> Pokecard { get; set; }
        public virtual DbSet<TCG_CollectionGame.Enities.Models.Pokeset> Pokeset { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string[] names = { "Base", "Jungle", "Wizards Black Star Promos", "Fossil", "Base Set 2", "Team Rocket", "Gym Heroes", "Gym Challenge", "Neo Genesis", "Neo Discovery", "Southern Islands", "Neo Revelation", "Neo Destiny", "Legendary Collection", "Expedition Base Set", "Aquapolis", "Skyridge", "Ruby & Sapphire", "Dragon", "Sandstorm", "Nintendo Black Star Promos", "Team Magma vs Team Aqua", "Hidden Legends", "FireRed & LeafGreen", "POP Series 1", "Team Rocket Returns", "Deoxys", "Emerald", "Unseen Forces", "POP Series 2", "Delta Species", "Legend Maker", "POP Series 3", "Holon Phantoms", "POP Series 4", "Crystal Guardians", "Dragon Frontiers", "Power Keepers", "POP Series 5", "Diamond & Pearl", "DP Black Star Promos", "Mysterious Treasures", "POP Series 6", "Secret Wonders", "Great Encounters", "POP Series 7", "Majestic Dawn", "Legends Awakened", "POP Series 8", "Stormfront", "Platinum", "POP Series 9", "Rising Rivals", "Supreme Victors", "Arceus", "Pokemon Rumble", "HGSS Black Star Promos", "HeartGold & SoulSilver", "HS-Unleashed", "HS-Undaunted", "HS-Triumphant", "Call of Legends", "BW Black Star Promos", "Black & White", "Emerging Powers", "Noble Victories", "Next Destinies", "Dark Explorers", "Dragons Exalted", "Dragon Vault", "Boundaries Crossed", "Plasma Storm", "Plasma Freeze", "Plasma Blast", "XY Black Star Promos", "Legendary Treasures", "Kalos Starter Set", "XY", "Flashfire", "Furious Fists", "Phantom Forces", "Primal Clash", "Double Crisis", "Roaring Skies", "Ancient Origins", "BREAKthrough", "BREAKpoint", "Generations", "Fates Collide", "Steam Siege", "Evolutions", "SM Black Star Promos", "Sun & Moon", "Guardians Rising", "Burning Shadows", "Shining Legends", "Crimson Invasion", "Ultra Prism", "Forbidden Light", "Celestial Storm", "Dragon Majesty", "Lost Thunder", "Team Up", "Detective Pikachu", "Unbroken Bonds", "Unified Minds", "Hidden Fates", "Shiny Vault", "Cosmic Eclipse", "SWSH Black Star Promos", "Sword & Shield", "Rebel Clash", "Darkness Ablaze", "Champion's Path", "Vivid Voltage", "Shining Fates", "Shiny Vault", "Battle Styles", "Chilling Reign" };
            string[] codes = { "base1", "base2", "basep", "base3", "base4", "base5", "gym1", "gym2", "neo1", "neo2", "si1", "neo3", "neo4", "base6", "ecard1", "ecard2", "ecard3", "ex1", "ex3", "ex2", "np", "ex4", "ex5", "ex6", "pop1", "ex7", "ex8", "ex9", "ex10", "pop2", "ex11", "ex12", "pop3", "ex13", "pop4", "ex14", "ex15", "ex16", "pop5", "dp1", "dpp", "dp2", "pop6", "dp3", "dp4", "pop7", "dp5", "dp6", "pop8", "dp7", "pl1", "pop9", "pl2", "pl3", "pl4", "ru1", "hsp", "hgss1", "hgss2", "hgss3", "hgss4", "col1", "bwp", "bw1", "bw2", "bw3", "bw4", "bw5", "bw6", "dv1", "bw7", "bw8", "bw9", "bw10", "xyp", "bw11", "xy0", "xy1", "xy2", "xy3", "xy4", "xy5", "dc1", "xy6", "xy7", "xy8", "xy9", "g1", "xy10", "xy11", "xy12", "smp", "sm1", "sm2", "sm3", "sm35", "sm4", "sm5", "sm6", "sm7", "sm75", "sm8", "sm9", "det1", "sm10", "sm11", "sm115", "sma", "sm12", "swshp", "swsh1", "swsh2", "swsh3", "swsh35", "swsh4", "swsh45", "swsh45sv", "swsh5", "swsh6" };

            for (int i = 0; i < names.Length; i++)
            {
                modelBuilder.Entity<Pokeset>().HasData(new Pokeset { ID = (i + 1), SetName = names[i], SetCode = codes[i] });
            }
        }
    }
}