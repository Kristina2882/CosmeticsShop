using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CosmeticsShop.Migrations
{
    public partial class AddCosmeticCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CosmeticCategory",
                table: "Cosmetics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CosmeticCategory",
                table: "Cosmetics");
        }
    }
}
