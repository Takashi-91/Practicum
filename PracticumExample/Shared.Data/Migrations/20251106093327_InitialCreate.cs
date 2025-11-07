using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderEvents",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OccurredUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEvents", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "ProcessedOrders",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProcessedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessedOrders", x => x.OrderId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderEvents");

            migrationBuilder.DropTable(
                name: "ProcessedOrders");
        }
    }
}
