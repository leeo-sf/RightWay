using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RightWay.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Identificador"),
                    weight = table.Column<float>(type: "real", nullable: false, comment: "Peso"),
                    height = table.Column<float>(type: "real", nullable: false, comment: "Altura"),
                    priority_level = table.Column<string>(type: "text", nullable: false, comment: "Nível de prioridade"),
                    status = table.Column<string>(type: "text", nullable: false, comment: "Status"),
                    address_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Endereço de entrega"),
                    created_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de criação"),
                    updated_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vehicle",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Identificador"),
                    plate_number = table.Column<string>(type: "text", nullable: false, comment: "Número da placa"),
                    model = table.Column<string>(type: "text", nullable: false, comment: "Modelo do veículo"),
                    capacity = table.Column<float>(type: "real", nullable: false, comment: "Capacidade do veículo"),
                    driver_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Motorista"),
                    route_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Rota do veículo"),
                    created_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de criação"),
                    updated_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "driver",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Identificador"),
                    name = table.Column<string>(type: "text", nullable: false, comment: "Nome"),
                    driver_lincense_number = table.Column<string>(type: "text", nullable: false, comment: "Número da carteira de motorista"),
                    phone = table.Column<string>(type: "text", nullable: false, comment: "Telefone"),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    created_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de criação"),
                    updated_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_driver", x => x.id);
                    table.ForeignKey(
                        name: "FK_driver_vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "vehicle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "route",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Identificador"),
                    estimated_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data estimada de partida"),
                    estimated_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data estimada de finalização da rota"),
                    total_distance_km = table.Column<float>(type: "real", nullable: false, comment: "Total da rota em KM"),
                    status = table.Column<string>(type: "text", nullable: false, comment: "Status"),
                    departure_address_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Endereço de partida"),
                    vehicle_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Veículo que será utilizado"),
                    created_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de criação"),
                    updated_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_route", x => x.id);
                    table.ForeignKey(
                        name: "FK_route_vehicle_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "address",
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
                    number = table.Column<int>(type: "integer", nullable: false, comment: "Número"),
                    municipal_code = table.Column<int>(type: "integer", nullable: false, comment: "Código municipal"),
                    latitude = table.Column<float>(type: "real", nullable: false, comment: "Latitude"),
                    longitude = table.Column<float>(type: "real", nullable: false, comment: "Longitude"),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Pedido"),
                    route_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Rota"),
                    created_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de criação"),
                    updated_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_address_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_address_route_route_id",
                        column: x => x.route_id,
                        principalTable: "route",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "route_order",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Identificador"),
                    route_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Rota"),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Pedido"),
                    delivery_order = table.Column<int>(type: "integer", nullable: false, comment: "Ordem de entrega"),
                    created_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de criação"),
                    updated_in = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Data de atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_route_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_route_order_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_route_order_route_route_id",
                        column: x => x.route_id,
                        principalTable: "route",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_order_id",
                table: "address",
                column: "order_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_address_route_id",
                table: "address",
                column: "route_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_driver_VehicleId",
                table: "driver",
                column: "VehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_route_vehicle_id",
                table: "route",
                column: "vehicle_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_route_order_order_id",
                table: "route_order",
                column: "order_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_route_order_route_id",
                table: "route_order",
                column: "route_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "driver");

            migrationBuilder.DropTable(
                name: "route_order");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "route");

            migrationBuilder.DropTable(
                name: "vehicle");
        }
    }
}
