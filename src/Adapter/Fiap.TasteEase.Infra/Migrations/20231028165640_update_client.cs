using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.TasteEase.Infra.Migrations
{
    /// <inheritdoc />
    public partial class update_client : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "taxpayerNumber",
                schema: "taste_ease",
                table: "client",
                newName: "taxpayer_number");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientModelId",
                schema: "taste_ease",
                table: "order_food",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_food_ClientModelId",
                schema: "taste_ease",
                table: "order_food",
                column: "ClientModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_food_client_ClientModelId",
                schema: "taste_ease",
                table: "order_food",
                column: "ClientModelId",
                principalSchema: "taste_ease",
                principalTable: "client",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_food_client_ClientModelId",
                schema: "taste_ease",
                table: "order_food");

            migrationBuilder.DropIndex(
                name: "IX_order_food_ClientModelId",
                schema: "taste_ease",
                table: "order_food");

            migrationBuilder.DropColumn(
                name: "ClientModelId",
                schema: "taste_ease",
                table: "order_food");

            migrationBuilder.RenameColumn(
                name: "taxpayer_number",
                schema: "taste_ease",
                table: "client",
                newName: "taxpayerNumber");
        }
    }
}
