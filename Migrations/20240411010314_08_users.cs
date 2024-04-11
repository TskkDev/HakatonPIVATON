﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HakatonPIVATON.Migrations
{
    /// <inheritdoc />
    public partial class _08_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remainder",
                table: "Good");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Remainder",
                table: "Good",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
