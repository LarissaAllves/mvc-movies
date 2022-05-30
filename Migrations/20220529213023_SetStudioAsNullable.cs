using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcMovie.Migrations
{
    public partial class SetStudioAsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Studio_StudioID",
                table: "Movie");

            migrationBuilder.AlterColumn<int>(
                name: "StudioID",
                table: "Movie",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movie",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Studio_StudioID",
                table: "Movie",
                column: "StudioID",
                principalTable: "Studio",
                principalColumn: "StudioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Studio_StudioID",
                table: "Movie");

            migrationBuilder.AlterColumn<int>(
                name: "StudioID",
                table: "Movie",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movie",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Studio_StudioID",
                table: "Movie",
                column: "StudioID",
                principalTable: "Studio",
                principalColumn: "StudioID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
