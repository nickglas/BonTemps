using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Migrations
{
    public partial class iets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NaamReserveerder",
                table: "Reserveringen",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobielTelefoonNummer",
                table: "Reserveringen",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Reserveringen",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Menu",
                table: "Menus",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bestelling",
                table: "Bestellingen",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gebruiker",
                columns: table => new
                {
                    GebruikerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Gebruiker = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruiker", x => x.GebruikerId);
                    table.ForeignKey(
                        name: "FK_Gebruiker_Reserveringen_Gebruiker",
                        column: x => x.Gebruiker,
                        principalTable: "Reserveringen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Menu",
                table: "Menus",
                column: "Menu");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellingen_Bestelling",
                table: "Bestellingen",
                column: "Bestelling");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruiker_Gebruiker",
                table: "Gebruiker",
                column: "Gebruiker");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestellingen_Reserveringen_Bestelling",
                table: "Bestellingen",
                column: "Bestelling",
                principalTable: "Reserveringen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Reserveringen_Menu",
                table: "Menus",
                column: "Menu",
                principalTable: "Reserveringen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestellingen_Reserveringen_Bestelling",
                table: "Bestellingen");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Reserveringen_Menu",
                table: "Menus");

            migrationBuilder.DropTable(
                name: "Gebruiker");

            migrationBuilder.DropIndex(
                name: "IX_Menus_Menu",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Bestellingen_Bestelling",
                table: "Bestellingen");

            migrationBuilder.DropColumn(
                name: "Menu",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Bestelling",
                table: "Bestellingen");

            migrationBuilder.AlterColumn<string>(
                name: "NaamReserveerder",
                table: "Reserveringen",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MobielTelefoonNummer",
                table: "Reserveringen",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Reserveringen",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
