using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Migrations
{
    public partial class idk2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergenen_Consumpties_ConsumptieId",
                table: "Allergenen");

            migrationBuilder.DropIndex(
                name: "IX_Allergenen_ConsumptieId",
                table: "Allergenen");

            migrationBuilder.DropColumn(
                name: "ConsumptieId",
                table: "Allergenen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsumptieId",
                table: "Allergenen",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Allergenen_ConsumptieId",
                table: "Allergenen",
                column: "ConsumptieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergenen_Consumpties_ConsumptieId",
                table: "Allergenen",
                column: "ConsumptieId",
                principalTable: "Consumpties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
