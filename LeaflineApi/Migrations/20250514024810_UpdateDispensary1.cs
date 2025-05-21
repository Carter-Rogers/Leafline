using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaflineApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDispensary1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "dispensaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "dispensaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "dispensaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "dispensaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "dispensaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "dispensaries");

            migrationBuilder.DropColumn(
                name: "City",
                table: "dispensaries");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "dispensaries");

            migrationBuilder.DropColumn(
                name: "State",
                table: "dispensaries");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "dispensaries");
        }
    }
}
