using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HakatonPIVATON.Migrations
{
    /// <inheritdoc />
    public partial class _13_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Point_StartPointId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "StartPointId",
                table: "Order",
                newName: "StartPointID");

            migrationBuilder.RenameColumn(
                name: "EndPointId",
                table: "Order",
                newName: "EndPointID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_StartPointId",
                table: "Order",
                newName: "IX_Order_StartPointID");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Route",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Order_EndPointID",
                table: "Order",
                column: "EndPointID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Point_EndPointID",
                table: "Order",
                column: "EndPointID",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Point_StartPointID",
                table: "Order",
                column: "StartPointID",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Point_Id",
                table: "Route",
                column: "Id",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Point_EndPointID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Point_StartPointID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_Point_Id",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Order_EndPointID",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "StartPointID",
                table: "Order",
                newName: "StartPointId");

            migrationBuilder.RenameColumn(
                name: "EndPointID",
                table: "Order",
                newName: "EndPointId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_StartPointID",
                table: "Order",
                newName: "IX_Order_StartPointId");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Route",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Point_StartPointId",
                table: "Order",
                column: "StartPointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
