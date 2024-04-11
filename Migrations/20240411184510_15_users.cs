using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HakatonPIVATON.Migrations
{
    /// <inheritdoc />
    public partial class _15_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Route_Point_Id",
                table: "Route");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Route",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Route_SecondPointId",
                table: "Route",
                column: "SecondPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Point_SecondPointId",
                table: "Route",
                column: "SecondPointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Route_Point_SecondPointId",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_SecondPointId",
                table: "Route");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Route",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Point_Id",
                table: "Route",
                column: "Id",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
