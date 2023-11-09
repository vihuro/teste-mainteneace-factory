using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMainteneace.Api.Migrations
{
    /// <inheritdoc />
    public partial class addUserInLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_location_tab_user_auth_UserAuthId",
                table: "tab_location");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tab_location");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserAuthId",
                table: "tab_location",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_location_tab_user_auth_UserAuthId",
                table: "tab_location",
                column: "UserAuthId",
                principalTable: "tab_user_auth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_location_tab_user_auth_UserAuthId",
                table: "tab_location");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserAuthId",
                table: "tab_location",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "tab_location",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_tab_location_tab_user_auth_UserAuthId",
                table: "tab_location",
                column: "UserAuthId",
                principalTable: "tab_user_auth",
                principalColumn: "Id");
        }
    }
}
