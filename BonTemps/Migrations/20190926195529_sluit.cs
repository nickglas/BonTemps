using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Migrations
{
    public partial class sluit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dinsdag",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "Donderdag",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "Maandag",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "Vrijdag",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "Woensdag",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "Zaterdag",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "Zondag",
                table: "ContactInfo");

            migrationBuilder.AddColumn<double>(
                name: "DinsdagOpen",
                table: "ContactInfo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DinsdagSluit",
                table: "ContactInfo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DonderdagOpen",
                table: "ContactInfo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DonderdagSluit",
                table: "ContactInfo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaandagOpen",
                table: "ContactInfo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaandagSluit",
                table: "ContactInfo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "VrijdagOpen",
                table: "ContactInfo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "VrijdagSluit",
                table: "ContactInfo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WoensdagOpen",
                table: "ContactInfo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WoensdagSluit",
                table: "ContactInfo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ZaterdagOpen",
                table: "ContactInfo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ZaterdagSluit",
                table: "ContactInfo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ZondagOpen",
                table: "ContactInfo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ZondagSluit",
                table: "ContactInfo",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DinsdagOpen",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "DinsdagSluit",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "DonderdagOpen",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "DonderdagSluit",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "MaandagOpen",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "MaandagSluit",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "VrijdagOpen",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "VrijdagSluit",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "WoensdagOpen",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "WoensdagSluit",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "ZaterdagOpen",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "ZaterdagSluit",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "ZondagOpen",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "ZondagSluit",
                table: "ContactInfo");

            migrationBuilder.AddColumn<DateTime>(
                name: "Dinsdag",
                table: "ContactInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Donderdag",
                table: "ContactInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Maandag",
                table: "ContactInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Vrijdag",
                table: "ContactInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Woensdag",
                table: "ContactInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Zaterdag",
                table: "ContactInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Zondag",
                table: "ContactInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
