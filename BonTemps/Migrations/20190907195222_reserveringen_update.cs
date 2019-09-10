using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Migrations
{
    public partial class reserveringen_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "Reserveringen",
                newName: "NaamReserveerder");

            migrationBuilder.AddColumn<int>(
                name: "AantalPersonen",
                table: "Reserveringen",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reserveringen",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HuisTelefoonNummer",
                table: "Reserveringen",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobielTelefoonNummer",
                table: "Reserveringen",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReserveringAangemaakt",
                table: "Reserveringen",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReserveringsDatum",
                table: "Reserveringen",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AantalPersonen",
                table: "Reserveringen");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reserveringen");

            migrationBuilder.DropColumn(
                name: "HuisTelefoonNummer",
                table: "Reserveringen");

            migrationBuilder.DropColumn(
                name: "MobielTelefoonNummer",
                table: "Reserveringen");

            migrationBuilder.DropColumn(
                name: "ReserveringAangemaakt",
                table: "Reserveringen");

            migrationBuilder.DropColumn(
                name: "ReserveringsDatum",
                table: "Reserveringen");

            migrationBuilder.RenameColumn(
                name: "NaamReserveerder",
                table: "Reserveringen",
                newName: "Naam");
        }
    }
}
