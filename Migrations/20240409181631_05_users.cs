using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HakatonPIVATON.Migrations
{
    /// <inheritdoc />
    public partial class _05_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersLocalities_Status_StatusId",
                table: "OrdersLocalities");

            migrationBuilder.DropTable(
                name: "Status");

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
                name: "FK_OrdersLocalities_StatusResponse_StatusId",
                table: "OrdersLocalities",
                column: "StatusId",
                principalTable: "StatusResponse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersLocalities_StatusResponse_StatusId",
                table: "OrdersLocalities");

            migrationBuilder.DropTable(
                name: "StatusResponse");

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
                name: "FK_OrdersLocalities_Status_StatusId",
                table: "OrdersLocalities",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
