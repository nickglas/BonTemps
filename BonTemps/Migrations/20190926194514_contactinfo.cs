using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Migrations
{
    public partial class contactinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adres = table.Column<string>(nullable: true),
                    Postocde = table.Column<string>(nullable: true),
                    Telefoonnummer = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Maandag = table.Column<DateTime>(nullable: false),
                    Dinsdag = table.Column<DateTime>(nullable: false),
                    Woensdag = table.Column<DateTime>(nullable: false),
                    Donderdag = table.Column<DateTime>(nullable: false),
                    Vrijdag = table.Column<DateTime>(nullable: false),
                    Zaterdag = table.Column<DateTime>(nullable: false),
                    Zondag = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfo");
        }
    }
}
