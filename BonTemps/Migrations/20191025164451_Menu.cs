using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Migrations
{
    public partial class Menu : Migration
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

            migrationBuilder.CreateTable(
                name: "ConsumptieMenu",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false),
                    ConsumptieId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumptieMenu", x => new { x.ConsumptieId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_ConsumptieMenu_Consumpties_ConsumptieId",
                        column: x => x.ConsumptieId,
                        principalTable: "Consumpties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumptieMenu_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptieMenu_MenuId",
                table: "ConsumptieMenu",
                column: "MenuId");

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

            migrationBuilder.DropTable(
                name: "ConsumptieMenu");

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
