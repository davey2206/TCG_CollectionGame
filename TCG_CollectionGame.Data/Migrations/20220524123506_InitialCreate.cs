using Microsoft.EntityFrameworkCore.Migrations;

namespace TCG_CollectionGame.Data.Migrations
{
    public partial class InitialCreate : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_Pokecard_PokesetID",
                table: "Pokecard",
                column: "PokesetID");

            migrationBuilder.CreateIndex(
                name: "IX_Pokecard_UserID",
                table: "Pokecard",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokecard");

            migrationBuilder.DropTable(
                name: "Pokeset");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
