using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CosmeticsShop.Migrations
{
    public partial class UpdateCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Cosmetics_CosmeticId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "CartItems",
                newName: "Price");

            migrationBuilder.AlterColumn<int>(
                name: "CosmeticId",
                table: "CartItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Cosmetics_CosmeticId",
                table: "CartItems",
                column: "CosmeticId",
                principalTable: "Cosmetics",
                principalColumn: "CosmeticId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Cosmetics_CosmeticId",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "CartItems",
                newName: "Quantity");

            migrationBuilder.AlterColumn<int>(
                name: "CosmeticId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Cosmetics_CosmeticId",
                table: "CartItems",
                column: "CosmeticId",
                principalTable: "Cosmetics",
                principalColumn: "CosmeticId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
