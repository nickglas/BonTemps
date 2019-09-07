using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservering");

            migrationBuilder.CreateTable(
                name: "Reserveringen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserveringen", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserveringen");

            migrationBuilder.CreateTable(
                name: "Reservering",
                columns: table => new
                {
                    ReserveringId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AantalPersonen = table.Column<int>(nullable: false),
                    Achternaam = table.Column<string>(nullable: true),
                    MobielNummer = table.Column<int>(nullable: false),
                    ReserveeringsDatum = table.Column<DateTime>(nullable: false),
                    Telefoonnummer = table.Column<int>(nullable: false),
                    Toevoeging = table.Column<string>(nullable: true),
                    Voornaam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservering", x => x.ReserveringId);
                });
        }
    }
}
