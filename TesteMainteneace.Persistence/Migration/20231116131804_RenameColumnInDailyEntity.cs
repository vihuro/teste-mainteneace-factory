using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMainteneace.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnInDailyEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_daily_tab_user_auth_UserAuthId",
                table: "tab_daily");

            migrationBuilder.DropIndex(
                name: "IX_tab_daily_UserAuthId",
                table: "tab_daily");

            migrationBuilder.DropColumn(
                name: "UserAuthId",
                table: "tab_daily");

            migrationBuilder.CreateIndex(
                name: "IX_tab_daily_UserCreatedId",
                table: "tab_daily",
                column: "UserCreatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_daily_tab_user_auth_UserCreatedId",
                table: "tab_daily",
                column: "UserCreatedId",
                principalTable: "tab_user_auth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_daily_tab_user_auth_UserCreatedId",
                table: "tab_daily");

            migrationBuilder.DropIndex(
                name: "IX_tab_daily_UserCreatedId",
                table: "tab_daily");

            migrationBuilder.AddColumn<Guid>(
                name: "UserAuthId",
                table: "tab_daily",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tab_daily_UserAuthId",
                table: "tab_daily",
                column: "UserAuthId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_daily_tab_user_auth_UserAuthId",
                table: "tab_daily",
                column: "UserAuthId",
                principalTable: "tab_user_auth",
                principalColumn: "Id");
        }
    }
}
