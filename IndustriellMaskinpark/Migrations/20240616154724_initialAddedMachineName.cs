using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndustriellMaskinpark.Migrations
{
    /// <inheritdoc />
    public partial class initialAddedMachineName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "Devices");
        }
    }
}
