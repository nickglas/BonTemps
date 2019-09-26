using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Migrations
{
    public partial class rolename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rolnaam",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rolnaam",
                table: "AspNetUsers");
        }
    }
}
