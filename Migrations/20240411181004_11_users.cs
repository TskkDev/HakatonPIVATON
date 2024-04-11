using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HakatonPIVATON.Migrations
{
    /// <inheritdoc />
    public partial class _11_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Route",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Route");
        }
    }
}
