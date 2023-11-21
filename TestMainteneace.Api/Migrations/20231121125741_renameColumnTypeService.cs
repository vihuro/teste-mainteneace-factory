using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMainteneace.Api.Migrations
{
    /// <inheritdoc />
    public partial class renameColumnTypeService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EType",
                table: "tab_order_service",
                newName: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "tab_order_service",
                newName: "EType");
        }
    }
}
