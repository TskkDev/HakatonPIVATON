using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HakatonPIVATON.Migrations
{
    /// <inheritdoc />
    public partial class _06_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersLocalities_Locality_LocalityId",
                table: "OrdersLocalities");

            migrationBuilder.AlterColumn<long>(
                name: "LocalityId",
                table: "OrdersLocalities",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "PointId",
                table: "OrdersLocalities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_OrdersLocalities_PointId",
                table: "OrdersLocalities",
                column: "PointId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersLocalities_Locality_LocalityId",
                table: "OrdersLocalities",
                column: "LocalityId",
                principalTable: "Locality",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersLocalities_Point_PointId",
                table: "OrdersLocalities",
                column: "PointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersLocalities_Locality_LocalityId",
                table: "OrdersLocalities");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersLocalities_Point_PointId",
                table: "OrdersLocalities");

            migrationBuilder.DropIndex(
                name: "IX_OrdersLocalities_PointId",
                table: "OrdersLocalities");

            migrationBuilder.DropColumn(
                name: "PointId",
                table: "OrdersLocalities");

            migrationBuilder.AlterColumn<long>(
                name: "LocalityId",
                table: "OrdersLocalities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersLocalities_Locality_LocalityId",
                table: "OrdersLocalities",
                column: "LocalityId",
                principalTable: "Locality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
