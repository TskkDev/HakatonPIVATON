using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HakatonPIVATON.Migrations
{
    /// <inheritdoc />
    public partial class _10_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersLocalities_Order_OrderId",
                table: "OrdersLocalities");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersLocalities_Point_PointId",
                table: "OrdersLocalities");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersLocalities_StatusResponse_StatusId",
                table: "OrdersLocalities");

            migrationBuilder.DropTable(
                name: "StatusResponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersLocalities",
                table: "OrdersLocalities");

            migrationBuilder.RenameTable(
                name: "OrdersLocalities",
                newName: "HistoryStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersLocalities_StatusId",
                table: "HistoryStatuses",
                newName: "IX_HistoryStatuses_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersLocalities_PointId",
                table: "HistoryStatuses",
                newName: "IX_HistoryStatuses_PointId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersLocalities_OrderId",
                table: "HistoryStatuses",
                newName: "IX_HistoryStatuses_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoryStatuses",
                table: "HistoryStatuses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryStatuses_Order_OrderId",
                table: "HistoryStatuses",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryStatuses_Point_PointId",
                table: "HistoryStatuses",
                column: "PointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryStatuses_Status_StatusId",
                table: "HistoryStatuses",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryStatuses_Order_OrderId",
                table: "HistoryStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryStatuses_Point_PointId",
                table: "HistoryStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryStatuses_Status_StatusId",
                table: "HistoryStatuses");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoryStatuses",
                table: "HistoryStatuses");

            migrationBuilder.RenameTable(
                name: "HistoryStatuses",
                newName: "OrdersLocalities");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryStatuses_StatusId",
                table: "OrdersLocalities",
                newName: "IX_OrdersLocalities_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryStatuses_PointId",
                table: "OrdersLocalities",
                newName: "IX_OrdersLocalities_PointId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryStatuses_OrderId",
                table: "OrdersLocalities",
                newName: "IX_OrdersLocalities_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersLocalities",
                table: "OrdersLocalities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StatusResponse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusResponse", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersLocalities_Order_OrderId",
                table: "OrdersLocalities",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersLocalities_Point_PointId",
                table: "OrdersLocalities",
                column: "PointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersLocalities_StatusResponse_StatusId",
                table: "OrdersLocalities",
                column: "StatusId",
                principalTable: "StatusResponse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
