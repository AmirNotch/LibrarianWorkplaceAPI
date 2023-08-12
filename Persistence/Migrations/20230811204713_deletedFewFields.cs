using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class deletedFewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeOfEvent",
                table: "Readers");

            migrationBuilder.DropColumn(
                name: "NumberOfEvent",
                table: "Readers");

            migrationBuilder.DropColumn(
                name: "DateTimeOfEvent",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "NumberOfEvent",
                table: "Books");

            migrationBuilder.AddColumn<bool>(
                name: "Exist",
                table: "Readers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Exist",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exist",
                table: "Readers");

            migrationBuilder.DropColumn(
                name: "Exist",
                table: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeOfEvent",
                table: "Readers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfEvent",
                table: "Readers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeOfEvent",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfEvent",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
