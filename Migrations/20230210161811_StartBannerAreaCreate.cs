using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopGrids.Migrations
{
    public partial class StartBannerAreaCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StartBannerAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ButtonText = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartBannerAreas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StartBannerAreas");
        }
    }
}
