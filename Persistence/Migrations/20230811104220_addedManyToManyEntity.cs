using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addedManyToManyEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Readers_ReaderId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ReaderId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ReaderId",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "BookReaders",
                columns: table => new
                {
                    BookGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReaderGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReaders", x => new { x.BookGuid, x.ReaderGuid });
                    table.ForeignKey(
                        name: "FK_BookReaders_Books_BookGuid",
                        column: x => x.BookGuid,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookReaders_Readers_ReaderGuid",
                        column: x => x.ReaderGuid,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookReaders_ReaderGuid",
                table: "BookReaders",
                column: "ReaderGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookReaders");

            migrationBuilder.AddColumn<Guid>(
                name: "ReaderId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_ReaderId",
                table: "Books",
                column: "ReaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Readers_ReaderId",
                table: "Books",
                column: "ReaderId",
                principalTable: "Readers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
