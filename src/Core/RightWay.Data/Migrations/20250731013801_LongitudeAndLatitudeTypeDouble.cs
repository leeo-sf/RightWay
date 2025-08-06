using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RightWay.Data.Migrations
{
    /// <inheritdoc />
    public partial class LongitudeAndLatitudeTypeDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Complement",
                table: "address",
                newName: "complement");

            migrationBuilder.AlterColumn<double>(
                name: "longitude",
                table: "base_address",
                type: "double precision",
                nullable: true,
                comment: "Longitude",
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true,
                oldComment: "Longitude");

            migrationBuilder.AlterColumn<double>(
                name: "latitude",
                table: "base_address",
                type: "double precision",
                nullable: false,
                comment: "Latitude",
                oldClrType: typeof(float),
                oldType: "real",
                oldComment: "Latitude");

            migrationBuilder.AlterColumn<string>(
                name: "complement",
                table: "address",
                type: "text",
                nullable: true,
                comment: "Complemento",
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "complement",
                table: "address",
                newName: "Complement");

            migrationBuilder.AlterColumn<float>(
                name: "longitude",
                table: "base_address",
                type: "real",
                nullable: true,
                comment: "Longitude",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "Longitude");

            migrationBuilder.AlterColumn<float>(
                name: "latitude",
                table: "base_address",
                type: "real",
                nullable: false,
                comment: "Latitude",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "Latitude");

            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                table: "address",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "Complemento");
        }
    }
}
