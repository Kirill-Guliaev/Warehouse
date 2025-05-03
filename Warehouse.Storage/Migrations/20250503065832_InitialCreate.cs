using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Storage.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Wearhouses",
                columns: table => new
                {
                    WearhouseId = table.Column<Guid>(type: "uuid", nullable: false),
                    StorageVolume = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    ArrivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    WearhouseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Persons_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Wearhouses_WearhouseId",
                        column: x => x.WearhouseId,
                        principalTable: "Wearhouses",
                        principalColumn: "WearhouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_OwnerId",
                table: "Items",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_WearhouseId",
                table: "Items",
                column: "WearhouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Wearhouses_OwnerId",
                table: "Wearhouses",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Wearhouses");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
