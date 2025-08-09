using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RightWay.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsRequiredBaseAddressSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "latitude",
                table: "base_address",
                type: "double precision",
                nullable: true,
                comment: "Latitude",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "Latitude");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "latitude",
                table: "base_address",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "Latitude",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "Latitude");
        }
    }
}
