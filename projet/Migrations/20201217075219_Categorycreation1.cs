using Microsoft.EntityFrameworkCore.Migrations;

namespace projet.Migrations
{
    public partial class Categorycreation1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livre_Category_CategoryId",
                table: "Livre");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Livre",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Livre_Category_CategoryId",
                table: "Livre",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livre_Category_CategoryId",
                table: "Livre");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Livre",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Livre_Category_CategoryId",
                table: "Livre",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
