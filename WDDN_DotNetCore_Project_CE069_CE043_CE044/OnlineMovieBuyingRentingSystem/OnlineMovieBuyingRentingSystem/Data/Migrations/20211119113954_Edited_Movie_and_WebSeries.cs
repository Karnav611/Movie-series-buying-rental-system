using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMovieBuyingRentingSystem.Data.Migrations
{
    public partial class Edited_Movie_and_WebSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WebSeriesFile",
                table: "WebSeriess");

            migrationBuilder.DropColumn(
                name: "MovieFile",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "Poster",
                table: "WebSeriess",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "WebSeriesFilePath",
                table: "WebSeriess",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Poster",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MovieFilePath",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WebSeriesFilePath",
                table: "WebSeriess");

            migrationBuilder.DropColumn(
                name: "MovieFilePath",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "Poster",
                table: "WebSeriess",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebSeriesFile",
                table: "WebSeriess",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Poster",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MovieFile",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
