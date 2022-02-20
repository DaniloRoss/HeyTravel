using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyTravel.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CittaPartenza",
                table: "eleViaggi");

            migrationBuilder.DropColumn(
                name: "StatoPartenza",
                table: "eleViaggi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CittaPartenza",
                table: "eleViaggi",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatoPartenza",
                table: "eleViaggi",
                type: "TEXT",
                nullable: true);
        }
    }
}
