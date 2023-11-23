using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TestMainteneace.Api.Migrations
{
    /// <inheritdoc />
    public partial class InsertColumnsFlowAndDaily : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_order_service_Locations_LocalExecutationId",
                table: "tab_order_service");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_tab_order_service_LocalExecutationId",
                table: "tab_order_service");

            migrationBuilder.RenameColumn(
                name: "LocalExecutationId",
                table: "tab_order_service",
                newName: "Situacion");

            migrationBuilder.AddColumn<int>(
                name: "EType",
                table: "tab_order_service",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationMainteneaceId",
                table: "tab_order_service",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "tab_order_service",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserCreatedId",
                table: "tab_order_service",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "tab_daily",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Observation = table.Column<string>(type: "text", nullable: true),
                    UserCreatedId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserAuthId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrderServiceId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_daily", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_daily_tab_order_service_OrderServiceId",
                        column: x => x.OrderServiceId,
                        principalTable: "tab_order_service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_daily_tab_user_auth_UserAuthId",
                        column: x => x.UserAuthId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tab_flow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeFlow = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_flow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Local = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_flow_order_service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    OrderServiceId = table.Column<int>(type: "integer", nullable: true),
                    FlowId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_flow_order_service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_flow_order_service_tab_flow_FlowId",
                        column: x => x.FlowId,
                        principalTable: "tab_flow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_flow_order_service_tab_order_service_OrderServiceId",
                        column: x => x.OrderServiceId,
                        principalTable: "tab_order_service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tab_end_user_flow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FlowOrderServiceId = table.Column<int>(type: "integer", nullable: false),
                    UserEndId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_end_user_flow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_end_user_flow_tab_flow_order_service_FlowOrderServiceId",
                        column: x => x.FlowOrderServiceId,
                        principalTable: "tab_flow_order_service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_end_user_flow_tab_user_auth_UserEndId",
                        column: x => x.UserEndId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_initial_user_flow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FlowOrderServiceId = table.Column<int>(type: "integer", nullable: false),
                    UserInitialId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreateded = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_initial_user_flow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_initial_user_flow_tab_flow_order_service_FlowOrderServi~",
                        column: x => x.FlowOrderServiceId,
                        principalTable: "tab_flow_order_service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_initial_user_flow_tab_user_auth_UserInitialId",
                        column: x => x.UserInitialId,
                        principalTable: "tab_user_auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_order_service_LocationMainteneaceId",
                table: "tab_order_service",
                column: "LocationMainteneaceId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_order_service_UserCreatedId",
                table: "tab_order_service",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_daily_OrderServiceId",
                table: "tab_daily",
                column: "OrderServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_daily_UserAuthId",
                table: "tab_daily",
                column: "UserAuthId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_end_user_flow_FlowOrderServiceId",
                table: "tab_end_user_flow",
                column: "FlowOrderServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tab_end_user_flow_UserEndId",
                table: "tab_end_user_flow",
                column: "UserEndId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_flow_order_service_FlowId",
                table: "tab_flow_order_service",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_flow_order_service_OrderServiceId",
                table: "tab_flow_order_service",
                column: "OrderServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_initial_user_flow_FlowOrderServiceId",
                table: "tab_initial_user_flow",
                column: "FlowOrderServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tab_initial_user_flow_UserInitialId",
                table: "tab_initial_user_flow",
                column: "UserInitialId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_order_service_tab_location_LocationMainteneaceId",
                table: "tab_order_service",
                column: "LocationMainteneaceId",
                principalTable: "tab_location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tab_order_service_tab_user_auth_UserCreatedId",
                table: "tab_order_service",
                column: "UserCreatedId",
                principalTable: "tab_user_auth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tab_order_service_tab_location_LocationMainteneaceId",
                table: "tab_order_service");

            migrationBuilder.DropForeignKey(
                name: "FK_tab_order_service_tab_user_auth_UserCreatedId",
                table: "tab_order_service");

            migrationBuilder.DropTable(
                name: "tab_daily");

            migrationBuilder.DropTable(
                name: "tab_end_user_flow");

            migrationBuilder.DropTable(
                name: "tab_initial_user_flow");

            migrationBuilder.DropTable(
                name: "tab_location");

            migrationBuilder.DropTable(
                name: "tab_flow_order_service");

            migrationBuilder.DropTable(
                name: "tab_flow");

            migrationBuilder.DropIndex(
                name: "IX_tab_order_service_LocationMainteneaceId",
                table: "tab_order_service");

            migrationBuilder.DropIndex(
                name: "IX_tab_order_service_UserCreatedId",
                table: "tab_order_service");

            migrationBuilder.DropColumn(
                name: "EType",
                table: "tab_order_service");

            migrationBuilder.DropColumn(
                name: "LocationMainteneaceId",
                table: "tab_order_service");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "tab_order_service");

            migrationBuilder.DropColumn(
                name: "UserCreatedId",
                table: "tab_order_service");

            migrationBuilder.RenameColumn(
                name: "Situacion",
                table: "tab_order_service",
                newName: "LocalExecutationId");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Local = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_order_service_LocalExecutationId",
                table: "tab_order_service",
                column: "LocalExecutationId");

            migrationBuilder.AddForeignKey(
                name: "FK_tab_order_service_Locations_LocalExecutationId",
                table: "tab_order_service",
                column: "LocalExecutationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
