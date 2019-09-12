using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumpties_Categories_CategoryId",
                table: "Consumpties");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Consumpties",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumpties_Categories_CategoryId",
                table: "Consumpties",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumpties_Categories_CategoryId",
                table: "Consumpties");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Consumpties",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Consumpties_Categories_CategoryId",
                table: "Consumpties",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
