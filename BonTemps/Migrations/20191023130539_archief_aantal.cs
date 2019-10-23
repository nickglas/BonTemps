using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Migrations
{
    public partial class archief_aantal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Aantal",
                table: "BestellingArchief",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aantal",
                table: "BestellingArchief");
        }
    }
}
