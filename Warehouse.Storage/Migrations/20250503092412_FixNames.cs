using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Storage.Migrations
{
    /// <inheritdoc />
    public partial class FixNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Wearhouses_WearhouseId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Wearhouses");

            migrationBuilder.RenameColumn(
                name: "WearhouseId",
                table: "Items",
                newName: "WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_WearhouseId",
                table: "Items",
                newName: "IX_Items_WarehouseId");

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<Guid>(type: "uuid", nullable: false),
                    StorageVolume = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                    table.ForeignKey(
                        name: "FK_Warehouses_Persons_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_OwnerId",
                table: "Warehouses",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Warehouses_WarehouseId",
                table: "Items",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Warehouses_WarehouseId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                table: "Items",
                newName: "WearhouseId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_WarehouseId",
                table: "Items",
                newName: "IX_Items_WearhouseId");

            migrationBuilder.CreateTable(
                name: "Wearhouses",
                columns: table => new
                {
                    WearhouseId = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    StorageVolume = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wearhouses", x => x.WearhouseId);
                    table.ForeignKey(
                        name: "FK_Wearhouses_Persons_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wearhouses_OwnerId",
                table: "Wearhouses",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Wearhouses_WearhouseId",
                table: "Items",
                column: "WearhouseId",
                principalTable: "Wearhouses",
                principalColumn: "WearhouseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
