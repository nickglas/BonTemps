using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Migrations
{
    public partial class personeel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Personeel_Aanmaakdatum",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personeel_RolId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Personeel_RolId",
                table: "AspNetUsers",
                column: "Personeel_RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_Personeel_RolId",
                table: "AspNetUsers",
                column: "Personeel_RolId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_Personeel_RolId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Personeel_RolId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Personeel_Aanmaakdatum",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Personeel_RolId",
                table: "AspNetUsers");
        }
    }
}
