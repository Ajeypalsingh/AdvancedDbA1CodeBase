using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class AddBrandNavigationAndBrandIdToLaptop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Brands",
                newName: "Id");

            migrationBuilder.AddColumn<Guid>(
                name: "BrandId",
                table: "Laptops",
                type: "uniqueidentifier",
                nullable: false
                );

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_BrandId",
                table: "Laptops",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_Brands_BrandId",
                table: "Laptops",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_Brands_BrandId",
                table: "Laptops");

            migrationBuilder.DropIndex(
                name: "IX_Laptops_BrandId",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Laptops");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Brands",
                newName: "BrandId");
        }
    }
}
