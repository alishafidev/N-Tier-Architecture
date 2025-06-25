using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class BookPublishDateChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Books",
                newSchema: "public");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "PublishDate",
                schema: "public",
                table: "Books",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Books",
                schema: "public",
                newName: "Books");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishDate",
                table: "Books",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
