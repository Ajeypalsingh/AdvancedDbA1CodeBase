using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class StoreLaptopRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoreLocation",
                columns: table => new
                {
                    StoreNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StreetNameNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanadianProvince = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreLocation", x => x.StoreNumber);
                });

            migrationBuilder.CreateTable(
                name: "StoreLaptop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Laptopid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreLocationStoreNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LaptopStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreLaptop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreLaptop_Laptops_Laptopid",
                        column: x => x.Laptopid,
                        principalTable: "Laptops",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreLaptop_StoreLocation_StoreLocationStoreNumber",
                        column: x => x.StoreLocationStoreNumber,
                        principalTable: "StoreLocation",
                        principalColumn: "StoreNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreLaptop_Laptopid",
                table: "StoreLaptop",
                column: "Laptopid");

            migrationBuilder.CreateIndex(
                name: "IX_StoreLaptop_StoreLocationStoreNumber",
                table: "StoreLaptop",
                column: "StoreLocationStoreNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreLaptop");

            migrationBuilder.DropTable(
                name: "StoreLocation");
        }
    }
}
