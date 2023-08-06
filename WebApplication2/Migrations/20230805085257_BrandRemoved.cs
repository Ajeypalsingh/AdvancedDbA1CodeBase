using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class BrandRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_Brands_BrandId1",
                table: "Laptops");

            migrationBuilder.DropIndex(
                name: "IX_Laptops_BrandId1",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "BrandId1",
                table: "Laptops");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Laptops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "BrandId1",
                table: "Laptops",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_BrandId1",
                table: "Laptops",
                column: "BrandId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_Brands_BrandId1",
                table: "Laptops",
                column: "BrandId1",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
