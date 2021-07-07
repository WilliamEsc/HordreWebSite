using Microsoft.EntityFrameworkCore.Migrations;

namespace HordeWebSite.Migrations
{
    public partial class ajoutDownTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Down",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roadImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    member1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    member2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    member3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    member4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    member5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    member6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    member7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    member8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job8 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Down", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Down");
        }
    }
}
