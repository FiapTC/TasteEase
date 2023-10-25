using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.TasteEase.Infra.Migrations
{
    /// <inheritdoc />
    public partial class add_order_food : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order_food",
                schema: "taste_ease",
                columns: table => new
                {
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    food_id = table.Column<Guid>(type: "uuid", nullable: false),
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FoodModelId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrderModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_food", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_food_food_FoodModelId",
                        column: x => x.FoodModelId,
                        principalSchema: "taste_ease",
                        principalTable: "food",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_order_food_order_OrderModelId",
                        column: x => x.OrderModelId,
                        principalSchema: "taste_ease",
                        principalTable: "order",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_food_FoodModelId",
                schema: "taste_ease",
                table: "order_food",
                column: "FoodModelId");

            migrationBuilder.CreateIndex(
                name: "IX_order_food_OrderModelId",
                schema: "taste_ease",
                table: "order_food",
                column: "OrderModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_food",
                schema: "taste_ease");
        }
    }
}
