using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RightWay.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsRequiredLatitudeAndLogitudeAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "longitude",
                table: "base_address",
                type: "real",
                nullable: true,
                comment: "Longitude",
                oldClrType: typeof(float),
                oldType: "real",
                oldComment: "Longitude");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "longitude",
                table: "base_address",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                comment: "Longitude",
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true,
                oldComment: "Longitude");
        }
    }
}
