using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Migrations
{
    public partial class menu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumpties_Menus_MenuId",
                table: "Consumpties");

            migrationBuilder.DropColumn(
                name: "ConsumptieId",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Consumpties",
                newName: "consumptieId");

            migrationBuilder.RenameIndex(
                name: "IX_Consumpties_MenuId",
                table: "Consumpties",
                newName: "IX_Consumpties_consumptieId");

            migrationBuilder.AddColumn<int>(
                name: "Consumptie",
                table: "Consumpties",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consumpties_Consumptie",
                table: "Consumpties",
                column: "Consumptie");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumpties_Menus_Consumptie",
                table: "Consumpties",
                column: "Consumptie",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumpties_Consumpties_consumptieId",
                table: "Consumpties",
                column: "consumptieId",
                principalTable: "Consumpties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumpties_Menus_Consumptie",
                table: "Consumpties");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumpties_Consumpties_consumptieId",
                table: "Consumpties");

            migrationBuilder.DropIndex(
                name: "IX_Consumpties_Consumptie",
                table: "Consumpties");

            migrationBuilder.DropColumn(
                name: "Consumptie",
                table: "Consumpties");

            migrationBuilder.RenameColumn(
                name: "consumptieId",
                table: "Consumpties",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Consumpties_consumptieId",
                table: "Consumpties",
                newName: "IX_Consumpties_MenuId");

            migrationBuilder.AddColumn<int>(
                name: "ConsumptieId",
                table: "Menus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumpties_Menus_MenuId",
                table: "Consumpties",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
