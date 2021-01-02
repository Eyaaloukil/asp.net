using Microsoft.EntityFrameworkCore.Migrations;

namespace projet.Migrations
{
    public partial class InitialCreate134 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livre_Auteur_AuteurId",
                table: "Livre");

            migrationBuilder.AlterColumn<int>(
                name: "AuteurId",
                table: "Livre",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "AuteurId",
                table: "Livre",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Livre_Auteur_AuteurId",
                table: "Livre",
                column: "AuteurId",
                principalTable: "Auteur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
