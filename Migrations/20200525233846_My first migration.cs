using Microsoft.EntityFrameworkCore.Migrations;

namespace KodApp.Migrations
{
    public partial class Myfirstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kods",
                columns: table => new
                {
                    videokeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    songNumber = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: false),
                    artist = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kods", x => x.videokeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kods");
        }
    }
}
