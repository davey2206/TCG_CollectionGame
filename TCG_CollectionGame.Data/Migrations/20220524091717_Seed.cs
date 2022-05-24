using Microsoft.EntityFrameworkCore.Migrations;

namespace TCG_CollectionGame.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pokeset",
                columns: new[] { "ID", "SetCode", "SetName" },
                values: new object[,]
                {
                    { 1, "base1", "Base" },
                    { 87, "xy9", "BREAKpoint" },
                    { 86, "xy8", "BREAKthrough" },
                    { 85, "xy7", "Ancient Origins" },
                    { 84, "xy6", "Roaring Skies" },
                    { 83, "dc1", "Double Crisis" },
                    { 82, "xy5", "Primal Clash" },
                    { 81, "xy4", "Phantom Forces" },
                    { 80, "xy3", "Furious Fists" },
                    { 79, "xy2", "Flashfire" },
                    { 78, "xy1", "XY" },
                    { 77, "xy0", "Kalos Starter Set" },
                    { 76, "bw11", "Legendary Treasures" },
                    { 88, "g1", "Generations" },
                    { 75, "xyp", "XY Black Star Promos" },
                    { 73, "bw9", "Plasma Freeze" },
                    { 72, "bw8", "Plasma Storm" },
                    { 71, "bw7", "Boundaries Crossed" },
                    { 70, "dv1", "Dragon Vault" },
                    { 69, "bw6", "Dragons Exalted" },
                    { 68, "bw5", "Dark Explorers" },
                    { 67, "bw4", "Next Destinies" },
                    { 66, "bw3", "Noble Victories" },
                    { 65, "bw2", "Emerging Powers" },
                    { 64, "bw1", "Black & White" },
                    { 63, "bwp", "BW Black Star Promos" },
                    { 62, "col1", "Call of Legends" },
                    { 74, "bw10", "Plasma Blast" },
                    { 61, "hgss4", "HS-Triumphant" },
                    { 89, "xy10", "Fates Collide" },
                    { 91, "xy12", "Evolutions" },
                    { 117, "swsh45sv", "Shiny Vault" },
                    { 116, "swsh45", "Shining Fates" },
                    { 115, "swsh4", "Vivid Voltage" },
                    { 114, "swsh35", "Champion's Path" },
                    { 113, "swsh3", "Darkness Ablaze" },
                    { 112, "swsh2", "Rebel Clash" },
                    { 111, "swsh1", "Sword & Shield" },
                    { 110, "swshp", "SWSH Black Star Promos" },
                    { 109, "sm12", "Cosmic Eclipse" },
                    { 108, "sma", "Shiny Vault" },
                    { 107, "sm115", "Hidden Fates" },
                    { 106, "sm11", "Unified Minds" },
                    { 90, "xy11", "Steam Siege" },
                    { 105, "sm10", "Unbroken Bonds" },
                    { 103, "sm9", "Team Up" },
                    { 102, "sm8", "Lost Thunder" },
                    { 101, "sm75", "Dragon Majesty" },
                    { 100, "sm7", "Celestial Storm" },
                    { 99, "sm6", "Forbidden Light" },
                    { 98, "sm5", "Ultra Prism" },
                    { 97, "sm4", "Crimson Invasion" },
                    { 96, "sm35", "Shining Legends" },
                    { 95, "sm3", "Burning Shadows" },
                    { 94, "sm2", "Guardians Rising" },
                    { 93, "sm1", "Sun & Moon" },
                    { 92, "smp", "SM Black Star Promos" },
                    { 104, "det1", "Detective Pikachu" },
                    { 118, "swsh5", "Battle Styles" },
                    { 60, "hgss3", "HS-Undaunted" },
                    { 58, "hgss1", "HeartGold & SoulSilver" },
                    { 27, "ex8", "Deoxys" },
                    { 26, "ex7", "Team Rocket Returns" },
                    { 25, "pop1", "POP Series 1" },
                    { 24, "ex6", "FireRed & LeafGreen" },
                    { 23, "ex5", "Hidden Legends" },
                    { 22, "ex4", "Team Magma vs Team Aqua" },
                    { 21, "np", "Nintendo Black Star Promos" },
                    { 20, "ex2", "Sandstorm" },
                    { 19, "ex3", "Dragon" },
                    { 18, "ex1", "Ruby & Sapphire" },
                    { 17, "ecard3", "Skyridge" },
                    { 16, "ecard2", "Aquapolis" },
                    { 28, "ex9", "Emerald" },
                    { 15, "ecard1", "Expedition Base Set" },
                    { 13, "neo4", "Neo Destiny" },
                    { 12, "neo3", "Neo Revelation" },
                    { 11, "si1", "Southern Islands" },
                    { 10, "neo2", "Neo Discovery" },
                    { 9, "neo1", "Neo Genesis" },
                    { 8, "gym2", "Gym Challenge" },
                    { 7, "gym1", "Gym Heroes" },
                    { 6, "base5", "Team Rocket" },
                    { 5, "base4", "Base Set 2" },
                    { 4, "base3", "Fossil" },
                    { 3, "basep", "Wizards Black Star Promos" },
                    { 2, "base2", "Jungle" },
                    { 14, "base6", "Legendary Collection" },
                    { 59, "hgss2", "HS-Unleashed" },
                    { 29, "ex10", "Unseen Forces" },
                    { 31, "ex11", "Delta Species" },
                    { 57, "hsp", "HGSS Black Star Promos" },
                    { 56, "ru1", "Pokemon Rumble" },
                    { 55, "pl4", "Arceus" },
                    { 54, "pl3", "Supreme Victors" },
                    { 53, "pl2", "Rising Rivals" },
                    { 52, "pop9", "POP Series 9" },
                    { 51, "pl1", "Platinum" },
                    { 50, "dp7", "Stormfront" },
                    { 49, "pop8", "POP Series 8" },
                    { 48, "dp6", "Legends Awakened" },
                    { 47, "dp5", "Majestic Dawn" },
                    { 46, "pop7", "POP Series 7" },
                    { 30, "pop2", "POP Series 2" },
                    { 45, "dp4", "Great Encounters" },
                    { 43, "pop6", "POP Series 6" },
                    { 42, "dp2", "Mysterious Treasures" },
                    { 41, "dpp", "DP Black Star Promos" },
                    { 40, "dp1", "Diamond & Pearl" },
                    { 39, "pop5", "POP Series 5" },
                    { 38, "ex16", "Power Keepers" },
                    { 37, "ex15", "Dragon Frontiers" },
                    { 36, "ex14", "Crystal Guardians" },
                    { 35, "pop4", "POP Series 4" },
                    { 34, "ex13", "Holon Phantoms" },
                    { 33, "pop3", "POP Series 3" },
                    { 32, "ex12", "Legend Maker" },
                    { 44, "dp3", "Secret Wonders" },
                    { 119, "swsh6", "Chilling Reign" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Pokeset",
                keyColumn: "ID",
                keyValue: 119);
        }
    }
}
