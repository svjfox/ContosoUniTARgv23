using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoUniTARgv23.Migrations
{
    /// <inheritdoc />
    public partial class Ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName1",
                table: "Instructor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName1",
                table: "Instructor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
