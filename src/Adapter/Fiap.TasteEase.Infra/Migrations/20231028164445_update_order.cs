using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.TasteEase.Infra.Migrations
{
    /// <inheritdoc />
    public partial class update_order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by",
                schema: "taste_ease",
                table: "order");

            migrationBuilder.DropColumn(
                name: "updated_by",
                schema: "taste_ease",
                table: "order");

            migrationBuilder.AddColumn<Guid>(
                name: "client_id",
                schema: "taste_ease",
                table: "order",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"))
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.CreateIndex(
                name: "IX_order_client_id",
                schema: "taste_ease",
                table: "order",
                column: "client_id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_client_client_id",
                schema: "taste_ease",
                table: "order",
                column: "client_id",
                principalSchema: "taste_ease",
                principalTable: "client",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_client_client_id",
                schema: "taste_ease",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_order_client_id",
                schema: "taste_ease",
                table: "order");

            migrationBuilder.DropColumn(
                name: "client_id",
                schema: "taste_ease",
                table: "order");

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                schema: "taste_ease",
                table: "order",
                type: "character varying(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                schema: "taste_ease",
                table: "order",
                type: "character varying(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "");
        }
    }
}
