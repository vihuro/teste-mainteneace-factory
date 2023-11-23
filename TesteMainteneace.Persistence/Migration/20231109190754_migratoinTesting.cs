using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMainteneace.Api.Migrations
{
    /// <inheritdoc />
    public partial class migratoinTesting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserAuthId",
                table: "tab_location",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "tab_location",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tab_location_UserAuthId",
                table: "tab_location",
                column: "UserAuthId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_location_tab_user_auth_UserAuthId",
                table: "tab_location",
                column: "UserAuthId",
                principalTable: "tab_user_auth",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_location_tab_user_auth_UserAuthId",
                table: "tab_location");

            migrationBuilder.DropIndex(
                name: "IX_tab_location_UserAuthId",
                table: "tab_location");

            migrationBuilder.DropColumn(
                name: "UserAuthId",
                table: "tab_location");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tab_location");
        }
    }
}
