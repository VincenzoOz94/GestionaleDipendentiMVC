using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionaleDipendentiMVC.Migrations
{
    /// <inheritdoc />
    public partial class primaMigrazione : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ruolo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeRuolo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruolo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dipendente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cognome = table.Column<string>(type: "TEXT", nullable: false),
                    Stipendio = table.Column<double>(type: "REAL", nullable: false),
                    RuoloId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dipendente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dipendente_Ruolo_RuoloId",
                        column: x => x.RuoloId,
                        principalTable: "Ruolo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dipendente_RuoloId",
                table: "Dipendente",
                column: "RuoloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dipendente");

            migrationBuilder.DropTable(
                name: "Ruolo");
        }
    }
}
