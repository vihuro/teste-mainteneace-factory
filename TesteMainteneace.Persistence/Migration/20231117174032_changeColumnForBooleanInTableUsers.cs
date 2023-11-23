using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMainteneace.Api.Migrations
{
    /// <inheritdoc />
    public partial class changeColumnForBooleanInTableUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn("Actived", "tab_user_auth");

            migrationBuilder.AddColumn<bool>(
                name: "Actived",
                table: "tab_user_auth",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Actived",
                table: "tab_user_auth",
                type: "text",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }
    }
}
