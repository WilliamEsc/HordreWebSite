using Microsoft.EntityFrameworkCore.Migrations;

namespace HordeWebSite.Migrations
{
    public partial class DelNameGazette : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Gazettes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Gazettes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
