using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Migrations
{
    public partial class well : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ConsumptieMenu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "AllergenenIcoon",
                table: "Allergenen",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ConsumptieMenu");

            migrationBuilder.AlterColumn<string>(
                name: "AllergenenIcoon",
                table: "Allergenen",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
