using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RightWay.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsRequiresAddressSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_order_order_id",
                table: "address");

            migrationBuilder.DropForeignKey(
                name: "FK_address_route_route_id",
                table: "address");

            migrationBuilder.AlterColumn<Guid>(
                name: "route_id",
                table: "address",
                type: "uuid",
                nullable: true,
                comment: "Rota",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Rota");

            migrationBuilder.AlterColumn<Guid>(
                name: "order_id",
                table: "address",
                type: "uuid",
                nullable: true,
                comment: "Pedido",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldComment: "Pedido");

            migrationBuilder.AddForeignKey(
                name: "FK_address_order_order_id",
                table: "address",
                column: "order_id",
                principalTable: "order",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_address_route_route_id",
                table: "address",
                column: "route_id",
                principalTable: "route",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_order_order_id",
                table: "address");

            migrationBuilder.DropForeignKey(
                name: "FK_address_route_route_id",
                table: "address");

            migrationBuilder.AlterColumn<Guid>(
                name: "route_id",
                table: "address",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Rota",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true,
                oldComment: "Rota");

            migrationBuilder.AlterColumn<Guid>(
                name: "order_id",
                table: "address",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Pedido",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true,
                oldComment: "Pedido");

            migrationBuilder.AddForeignKey(
                name: "FK_address_order_order_id",
                table: "address",
                column: "order_id",
                principalTable: "order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_address_route_route_id",
                table: "address",
                column: "route_id",
                principalTable: "route",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
