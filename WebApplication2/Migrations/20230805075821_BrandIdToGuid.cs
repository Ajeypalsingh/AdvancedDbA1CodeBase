using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class BrandIdToGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_Brands_BrandId",
                table: "Laptops");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreLaptop_Laptops_Laptopid",
                table: "StoreLaptop");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreLaptop_StoreLocation_StoreLocationStoreNumber",
                table: "StoreLaptop");

            migrationBuilder.DropIndex(
                name: "IX_Laptops_BrandId",
                table: "Laptops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreLocation",
                table: "StoreLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreLaptop",
                table: "StoreLaptop");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "StoreLocation",
                newName: "StoreLocations");

            migrationBuilder.RenameTable(
                name: "StoreLaptop",
                newName: "StoreLaps");

            migrationBuilder.RenameIndex(
                name: "IX_StoreLaptop_StoreLocationStoreNumber",
                table: "StoreLaps",
                newName: "IX_StoreLaps_StoreLocationStoreNumber");

            migrationBuilder.RenameIndex(
                name: "IX_StoreLaptop_Laptopid",
                table: "StoreLaps",
                newName: "IX_StoreLaps_Laptopid");

            migrationBuilder.AddColumn<Guid>(
                name: "BrandId1",
                table: "Laptops",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BrandId",
                table: "Brands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreLocations",
                table: "StoreLocations",
                column: "StoreNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreLaps",
                table: "StoreLaps",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_StoreLaps_Laptops_Laptopid",
                table: "StoreLaps",
                column: "Laptopid",
                principalTable: "Laptops",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreLaps_StoreLocations_StoreLocationStoreNumber",
                table: "StoreLaps",
                column: "StoreLocationStoreNumber",
                principalTable: "StoreLocations",
                principalColumn: "StoreNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_Brands_BrandId1",
                table: "Laptops");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreLaps_Laptops_Laptopid",
                table: "StoreLaps");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreLaps_StoreLocations_StoreLocationStoreNumber",
                table: "StoreLaps");

            migrationBuilder.DropIndex(
                name: "IX_Laptops_BrandId1",
                table: "Laptops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreLocations",
                table: "StoreLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreLaps",
                table: "StoreLaps");

            migrationBuilder.DropColumn(
                name: "BrandId1",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "StoreLocations",
                newName: "StoreLocation");

            migrationBuilder.RenameTable(
                name: "StoreLaps",
                newName: "StoreLaptop");

            migrationBuilder.RenameIndex(
                name: "IX_StoreLaps_StoreLocationStoreNumber",
                table: "StoreLaptop",
                newName: "IX_StoreLaptop_StoreLocationStoreNumber");

            migrationBuilder.RenameIndex(
                name: "IX_StoreLaps_Laptopid",
                table: "StoreLaptop",
                newName: "IX_StoreLaptop_Laptopid");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreLocation",
                table: "StoreLocation",
                column: "StoreNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreLaptop",
                table: "StoreLaptop",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_StoreLaptop_Laptops_Laptopid",
                table: "StoreLaptop",
                column: "Laptopid",
                principalTable: "Laptops",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreLaptop_StoreLocation_StoreLocationStoreNumber",
                table: "StoreLaptop",
                column: "StoreLocationStoreNumber",
                principalTable: "StoreLocation",
                principalColumn: "StoreNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
