using Microsoft.EntityFrameworkCore.Migrations;

namespace HordeWebSite.Migrations
{
    public partial class changeImageNameDown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "roadImage",
                table: "Down",
                newName: "imageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imageName",
                table: "Down",
                newName: "roadImage");
        }
    }
}
