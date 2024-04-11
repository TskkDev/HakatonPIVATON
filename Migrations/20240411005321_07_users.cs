using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HakatonPIVATON.Migrations
{
    /// <inheritdoc />
    public partial class _07_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersLocalities_Locality_LocalityId",
                table: "OrdersLocalities");

            migrationBuilder.DropIndex(
                name: "IX_OrdersLocalities_LocalityId",
                table: "OrdersLocalities");

            migrationBuilder.DropColumn(
                name: "LocalityId",
                table: "OrdersLocalities");

            migrationBuilder.AddColumn<long>(
                name: "Remainder",
                table: "Good",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remainder",
                table: "Good");

            migrationBuilder.AddColumn<long>(
                name: "LocalityId",
                table: "OrdersLocalities",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdersLocalities_LocalityId",
                table: "OrdersLocalities",
                column: "LocalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersLocalities_Locality_LocalityId",
                table: "OrdersLocalities",
                column: "LocalityId",
                principalTable: "Locality",
                principalColumn: "Id");
        }
    }
}
