using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMainteneace.Api.Migrations
{
    /// <inheritdoc />
    public partial class renameColumnInTableFlowOrderService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_flow_order_service_tab_order_service_OrderServiceId",
                table: "tab_flow_order_service");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "tab_flow_order_service");

            migrationBuilder.AlterColumn<int>(
                name: "OrderServiceId",
                table: "tab_flow_order_service",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_flow_order_service_tab_order_service_OrderServiceId",
                table: "tab_flow_order_service",
                column: "OrderServiceId",
                principalTable: "tab_order_service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_flow_order_service_tab_order_service_OrderServiceId",
                table: "tab_flow_order_service");

            migrationBuilder.AlterColumn<int>(
                name: "OrderServiceId",
                table: "tab_flow_order_service",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "tab_flow_order_service",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_flow_order_service_tab_order_service_OrderServiceId",
                table: "tab_flow_order_service",
                column: "OrderServiceId",
                principalTable: "tab_order_service",
                principalColumn: "Id");
        }
    }
}
