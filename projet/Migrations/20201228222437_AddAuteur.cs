using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace projet.Migrations
{
    public partial class AddAuteur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuteurId",
                table: "Livre",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Auteur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteur", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livre_AuteurId",
                table: "Livre",
                column: "AuteurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livre_Auteur_AuteurId",
                table: "Livre",
                column: "AuteurId",
                principalTable: "Auteur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livre_Auteur_AuteurId",
                table: "Livre");

            migrationBuilder.DropTable(
                name: "Auteur");

            migrationBuilder.DropIndex(
                name: "IX_Livre_AuteurId",
                table: "Livre");

            migrationBuilder.DropColumn(
                name: "AuteurId",
                table: "Livre");
        }
    }
}
