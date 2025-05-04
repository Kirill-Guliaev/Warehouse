using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Storage.Migrations
{
    /// <inheritdoc />
    public partial class PriceForWarehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceForUnit",
                table: "Warehouses",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceForUnit",
                table: "Warehouses");
        }
    }
}
