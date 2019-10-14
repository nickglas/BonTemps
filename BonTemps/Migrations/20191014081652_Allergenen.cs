using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Migrations
{
    public partial class Allergenen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergenen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Beschrijving = table.Column<string>(nullable: true),
                    AllergenenIcoon = table.Column<string>(nullable: true),
                    ConsumptieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergenen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergenen_Consumpties_ConsumptieId",
                        column: x => x.ConsumptieId,
                        principalTable: "Consumpties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergenen_ConsumptieId",
                table: "Allergenen",
                column: "ConsumptieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergenen");
        }
    }
}
