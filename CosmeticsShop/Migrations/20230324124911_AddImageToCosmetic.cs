using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CosmeticsShop.Migrations
{
    public partial class AddImageToCosmetic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Cosmetics",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Cosmetics");
        }
    }
}
