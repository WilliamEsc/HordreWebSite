using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HordeWebSite.Migrations
{
    public partial class ChangeDateGazette : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "month",
                table: "Gazettes");

            migrationBuilder.DropColumn(
                name: "year",
                table: "Gazettes");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Gazettes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "Gazettes");

            migrationBuilder.AddColumn<int>(
                name: "month",
                table: "Gazettes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "Gazettes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
