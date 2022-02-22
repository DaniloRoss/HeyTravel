using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyTravel.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eleAssociazione",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username_Utente = table.Column<string>(type: "TEXT", nullable: true),
                    ID_Viaggio = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eleAssociazione", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "eleViaggi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StatoArrivo = table.Column<string>(type: "TEXT", nullable: true),
                    CittaArrivo = table.Column<string>(type: "TEXT", nullable: true),
                    MesePartenza = table.Column<string>(type: "TEXT", nullable: true),
                    MeseArrivo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eleViaggi", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eleAssociazione");

            migrationBuilder.DropTable(
                name: "eleViaggi");
        }
    }
}
