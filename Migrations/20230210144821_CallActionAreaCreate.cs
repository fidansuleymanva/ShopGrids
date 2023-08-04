using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopGrids.Migrations
{
    public partial class CallActionAreaCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title3",
                table: "CallActionAreas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title4",
                table: "CallActionAreas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title3",
                table: "CallActionAreas");

            migrationBuilder.DropColumn(
                name: "Title4",
                table: "CallActionAreas");
        }
    }
}
