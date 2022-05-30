using Microsoft.EntityFrameworkCore.Migrations;

namespace TCG_CollectionGame.Data.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokeset",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetCode = table.Column<string>(nullable: true),
                    SetName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokeset", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Coin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pokecard",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardCode = table.Column<string>(nullable: true),
                    CardImg = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    PokesetID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokecard", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pokecard_Pokeset_PokesetID",
                        column: x => x.PokesetID,
                        principalTable: "Pokeset",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokecard_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trade",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User1ID = table.Column<int>(nullable: true),
                    User2ID = table.Column<int>(nullable: true),
                    Card1ID = table.Column<int>(nullable: true),
                    Card2ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trade_Pokecard_Card1ID",
                        column: x => x.Card1ID,
                        principalTable: "Pokecard",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trade_Pokecard_Card2ID",
                        column: x => x.Card2ID,
                        principalTable: "Pokecard",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trade_User_User1ID",
                        column: x => x.User1ID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trade_User_User2ID",
                        column: x => x.User2ID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokecard_PokesetID",
                table: "Pokecard",
                column: "PokesetID");

            migrationBuilder.CreateIndex(
                name: "IX_Pokecard_UserID",
                table: "Pokecard",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_Card1ID",
                table: "Trade",
                column: "Card1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_Card2ID",
                table: "Trade",
                column: "Card2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_User1ID",
                table: "Trade",
                column: "User1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_User2ID",
                table: "Trade",
                column: "User2ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trade");

            migrationBuilder.DropTable(
                name: "Pokecard");

            migrationBuilder.DropTable(
                name: "Pokeset");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
