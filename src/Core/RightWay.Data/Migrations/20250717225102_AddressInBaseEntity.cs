using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RightWay.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddressInBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latitude",
                table: "address");

            migrationBuilder.DropColumn(
                name: "locality",
                table: "address");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "address");

            migrationBuilder.DropColumn(
                name: "municipal_code",
                table: "address");

            migrationBuilder.DropColumn(
                name: "neighborhood",
                table: "address");

            migrationBuilder.DropColumn(
                name: "public_place",
                table: "address");

            migrationBuilder.DropColumn(
                name: "region",
                table: "address");

            migrationBuilder.DropColumn(
                name: "state",
                table: "address");

            migrationBuilder.DropColumn(
                name: "uf",
                table: "address");

            migrationBuilder.DropColumn(
                name: "zip_code",
                table: "address");

            migrationBuilder.AddColumn<Guid>(
                name: "BaseAddressId",
                table: "address",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Complement",
                table: "address",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "base_address",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Identificador"),
                    zip_code = table.Column<string>(type: "text", nullable: false, comment: "CEP"),
                    public_place = table.Column<string>(type: "text", nullable: false, comment: "Logradouro"),
                    neighborhood = table.Column<string>(type: "text", nullable: false, comment: "Bairro"),
                    locality = table.Column<string>(type: "text", nullable: false, comment: "Localidade"),
                    uf = table.Column<string>(type: "text", nullable: false, comment: "Estado"),
                    state = table.Column<string>(type: "text", nullable: false, comment: "Estado"),
                    region = table.Column<string>(type: "text", nullable: false, comment: "Região"),
                    municipal_code = table.Column<int>(type: "integer", nullable: false, comment: "Código municipal"),
                    latitude = table.Column<float>(type: "real", nullable: false, comment: "Latitude"),
                    longitude = table.Column<float>(type: "real", nullable: false, comment: "Longitude"),
                    created_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de criação"),
                    updated_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_base_address", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_BaseAddressId",
                table: "address",
                column: "BaseAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_address_base_address_BaseAddressId",
                table: "address",
                column: "BaseAddressId",
                principalTable: "base_address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_base_address_BaseAddressId",
                table: "address");

            migrationBuilder.DropTable(
                name: "base_address");

            migrationBuilder.DropIndex(
                name: "IX_address_BaseAddressId",
                table: "address");

            migrationBuilder.DropColumn(
                name: "BaseAddressId",
                table: "address");

            migrationBuilder.DropColumn(
                name: "Complement",
                table: "address");

            migrationBuilder.AddColumn<float>(
                name: "latitude",
                table: "address",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                comment: "Latitude");

            migrationBuilder.AddColumn<string>(
                name: "locality",
                table: "address",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Localidade");

            migrationBuilder.AddColumn<float>(
                name: "longitude",
                table: "address",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                comment: "Longitude");

            migrationBuilder.AddColumn<int>(
                name: "municipal_code",
                table: "address",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Código municipal");

            migrationBuilder.AddColumn<string>(
                name: "neighborhood",
                table: "address",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Bairro");

            migrationBuilder.AddColumn<string>(
                name: "public_place",
                table: "address",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Logradouro");

            migrationBuilder.AddColumn<string>(
                name: "region",
                table: "address",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Região");

            migrationBuilder.AddColumn<string>(
                name: "state",
                table: "address",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Estado");

            migrationBuilder.AddColumn<string>(
                name: "uf",
                table: "address",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Estado");

            migrationBuilder.AddColumn<string>(
                name: "zip_code",
                table: "address",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "CEP");
        }
    }
}
