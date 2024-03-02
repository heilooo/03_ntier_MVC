using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ntier.Migrations
{
    /// <inheritdoc />
    public partial class AddCover1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "CoverTypes",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CoverTypes",
                newName: "MyProperty");
        }
    }
}
