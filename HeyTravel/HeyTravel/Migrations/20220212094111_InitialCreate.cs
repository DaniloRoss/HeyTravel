using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyTravel.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Casi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Stato = table.Column<string>(type: "TEXT", nullable: true),
                    CasiAttivi = table.Column<int>(type: "INTEGER", nullable: false),
                    CasiGiornalieri = table.Column<int>(type: "INTEGER", nullable: false),
                    Popolazione = table.Column<int>(type: "INTEGER", nullable: false),
                    PercentualeContagi = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Meteo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Stato = table.Column<string>(type: "TEXT", nullable: true),
                    Citta = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meteo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vaccini",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Stato = table.Column<string>(type: "TEXT", nullable: true),
                    Vaccinati = table.Column<int>(type: "INTEGER", nullable: false),
                    DosiTotali = table.Column<int>(type: "INTEGER", nullable: false),
                    NuoveDosi = table.Column<int>(type: "INTEGER", nullable: false),
                    PercentualeVaccini = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccini", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Mare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Mese = table.Column<string>(type: "TEXT", nullable: true),
                    Temperatura = table.Column<decimal>(type: "TEXT", nullable: false),
                    MeteoID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Mare_Meteo_MeteoID",
                        column: x => x.MeteoID,
                        principalTable: "Meteo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OreSole",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Mese = table.Column<string>(type: "TEXT", nullable: true),
                    MediaGiornaliera = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotaleMese = table.Column<int>(type: "INTEGER", nullable: false),
                    MeteoID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OreSole", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OreSole_Meteo_MeteoID",
                        column: x => x.MeteoID,
                        principalTable: "Meteo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Precipitazioni",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Mese = table.Column<string>(type: "TEXT", nullable: true),
                    Quantità = table.Column<int>(type: "INTEGER", nullable: false),
                    Giorni = table.Column<int>(type: "INTEGER", nullable: false),
                    MeteoID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precipitazioni", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Precipitazioni_Meteo_MeteoID",
                        column: x => x.MeteoID,
                        principalTable: "Meteo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Mese = table.Column<string>(type: "TEXT", nullable: true),
                    Min = table.Column<decimal>(type: "TEXT", nullable: false),
                    Max = table.Column<decimal>(type: "TEXT", nullable: false),
                    Media = table.Column<decimal>(type: "TEXT", nullable: false),
                    MeteoID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Temperature_Meteo_MeteoID",
                        column: x => x.MeteoID,
                        principalTable: "Meteo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Viaggio",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StatoPartenza = table.Column<string>(type: "TEXT", nullable: true),
                    StatoArrivo = table.Column<string>(type: "TEXT", nullable: true),
                    MeseArrivo = table.Column<string>(type: "TEXT", nullable: true),
                    VaccinatiID = table.Column<int>(type: "INTEGER", nullable: true),
                    CasiCovidID = table.Column<int>(type: "INTEGER", nullable: true),
                    MeteoID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viaggio", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Viaggio_Casi_CasiCovidID",
                        column: x => x.CasiCovidID,
                        principalTable: "Casi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Viaggio_Meteo_MeteoID",
                        column: x => x.MeteoID,
                        principalTable: "Meteo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Viaggio_Vaccini_VaccinatiID",
                        column: x => x.VaccinatiID,
                        principalTable: "Vaccini",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mare_MeteoID",
                table: "Mare",
                column: "MeteoID");

            migrationBuilder.CreateIndex(
                name: "IX_OreSole_MeteoID",
                table: "OreSole",
                column: "MeteoID");

            migrationBuilder.CreateIndex(
                name: "IX_Precipitazioni_MeteoID",
                table: "Precipitazioni",
                column: "MeteoID");

            migrationBuilder.CreateIndex(
                name: "IX_Temperature_MeteoID",
                table: "Temperature",
                column: "MeteoID");

            migrationBuilder.CreateIndex(
                name: "IX_Viaggio_CasiCovidID",
                table: "Viaggio",
                column: "CasiCovidID");

            migrationBuilder.CreateIndex(
                name: "IX_Viaggio_MeteoID",
                table: "Viaggio",
                column: "MeteoID");

            migrationBuilder.CreateIndex(
                name: "IX_Viaggio_VaccinatiID",
                table: "Viaggio",
                column: "VaccinatiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mare");

            migrationBuilder.DropTable(
                name: "OreSole");

            migrationBuilder.DropTable(
                name: "Precipitazioni");

            migrationBuilder.DropTable(
                name: "Temperature");

            migrationBuilder.DropTable(
                name: "Viaggio");

            migrationBuilder.DropTable(
                name: "Casi");

            migrationBuilder.DropTable(
                name: "Meteo");

            migrationBuilder.DropTable(
                name: "Vaccini");
        }
    }
}
