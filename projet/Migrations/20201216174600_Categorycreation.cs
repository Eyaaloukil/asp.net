using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace projet.Migrations
{
    public partial class Categorycreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categorie",
                table: "Livre");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Livre",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livre_CategoryId",
                table: "Livre",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livre_Category_CategoryId",
                table: "Livre",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livre_Category_CategoryId",
                table: "Livre");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Livre_CategoryId",
                table: "Livre");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Livre");

            migrationBuilder.AddColumn<string>(
                name: "Categorie",
                table: "Livre",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
