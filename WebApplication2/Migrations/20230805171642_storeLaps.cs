using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class storeLaps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreLaps_Laptops_Laptopid",
                table: "StoreLaps");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreLaps_StoreLocations_StoreLocationStoreNumber",
                table: "StoreLaps");

            migrationBuilder.DropIndex(
                name: "IX_StoreLaps_StoreLocationStoreNumber",
                table: "StoreLaps");

            migrationBuilder.DropColumn(
                name: "StoreLocationStoreNumber",
                table: "StoreLaps");

            migrationBuilder.RenameColumn(
                name: "Laptopid",
                table: "StoreLaps",
                newName: "LaptopId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreLaps_Laptopid",
                table: "StoreLaps",
                newName: "IX_StoreLaps_LaptopId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreLaps_StoreId",
                table: "StoreLaps",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreLaps_Laptops_LaptopId",
                table: "StoreLaps",
                column: "LaptopId",
                principalTable: "Laptops",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreLaps_StoreLocations_StoreId",
                table: "StoreLaps",
                column: "StoreId",
                principalTable: "StoreLocations",
                principalColumn: "StoreNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreLaps_Laptops_LaptopId",
                table: "StoreLaps");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreLaps_StoreLocations_StoreId",
                table: "StoreLaps");

            migrationBuilder.DropIndex(
                name: "IX_StoreLaps_StoreId",
                table: "StoreLaps");

            migrationBuilder.RenameColumn(
                name: "LaptopId",
                table: "StoreLaps",
                newName: "Laptopid");

            migrationBuilder.RenameIndex(
                name: "IX_StoreLaps_LaptopId",
                table: "StoreLaps",
                newName: "IX_StoreLaps_Laptopid");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreLocationStoreNumber",
                table: "StoreLaps",
                type: "uniqueidentifier",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_StoreLaps_StoreLocationStoreNumber",
                table: "StoreLaps",
                column: "StoreLocationStoreNumber");

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
    }
}
