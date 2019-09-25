using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumpties_Consumpties_consumptieId",
                table: "Consumpties");

            migrationBuilder.DropIndex(
                name: "IX_Consumpties_consumptieId",
                table: "Consumpties");

            migrationBuilder.DropColumn(
                name: "consumptieId",
                table: "Consumpties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "consumptieId",
                table: "Consumpties",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consumpties_consumptieId",
                table: "Consumpties",
                column: "consumptieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumpties_Consumpties_consumptieId",
                table: "Consumpties",
                column: "consumptieId",
                principalTable: "Consumpties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
