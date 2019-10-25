using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumpties_Menus_MenuId",
                table: "Consumpties");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Consumpties",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Consumpties_Menus_MenuId",
                table: "Consumpties",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumpties_Menus_MenuId",
                table: "Consumpties");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Consumpties",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumpties_Menus_MenuId",
                table: "Consumpties",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
