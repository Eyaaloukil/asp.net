using Microsoft.EntityFrameworkCore.Migrations;

namespace projet.Migrations
{
    public partial class AddAuteur1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livre_Auteur_AuteurId",
                table: "Livre");

            migrationBuilder.AlterColumn<int>(
                name: "AuteurId",
                table: "Livre",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Livre_Auteur_AuteurId",
                table: "Livre",
                column: "AuteurId",
                principalTable: "Auteur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livre_Auteur_AuteurId",
                table: "Livre");

            migrationBuilder.AlterColumn<int>(
                name: "AuteurId",
                table: "Livre",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Livre_Auteur_AuteurId",
                table: "Livre",
                column: "AuteurId",
                principalTable: "Auteur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
