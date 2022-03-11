using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMovieBuyingRentingSystem.Data.Migrations
{
    public partial class AlteredMoviePurchasesANDWebSeriesPurchasesAndRents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviePurchases_AspNetUsers_UserId1",
                table: "MoviePurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieRents_AspNetUsers_UserId1",
                table: "MovieRents");

            migrationBuilder.DropForeignKey(
                name: "FK_WebSeriesPurchases_AspNetUsers_UserId1",
                table: "WebSeriesPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_WebSeriesPurchases_Movies_MovieId",
                table: "WebSeriesPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_WebSeriesRents_AspNetUsers_UserId1",
                table: "WebSeriesRents");

            migrationBuilder.DropForeignKey(
                name: "FK_WebSeriesRents_Movies_MovieId",
                table: "WebSeriesRents");

            migrationBuilder.DropIndex(
                name: "IX_WebSeriesRents_MovieId",
                table: "WebSeriesRents");

            migrationBuilder.DropIndex(
                name: "IX_WebSeriesRents_UserId1",
                table: "WebSeriesRents");

            migrationBuilder.DropIndex(
                name: "IX_WebSeriesPurchases_MovieId",
                table: "WebSeriesPurchases");

            migrationBuilder.DropIndex(
                name: "IX_WebSeriesPurchases_UserId1",
                table: "WebSeriesPurchases");

            migrationBuilder.DropIndex(
                name: "IX_MovieRents_UserId1",
                table: "MovieRents");

            migrationBuilder.DropIndex(
                name: "IX_MoviePurchases_UserId1",
                table: "MoviePurchases");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "WebSeriesRents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WebSeriesRents");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "WebSeriesRents");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "WebSeriesPurchases");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WebSeriesPurchases");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "WebSeriesPurchases");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MovieRents");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "MovieRents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MoviePurchases");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "MoviePurchases");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "WebSeriesRents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "WebSeriesPurchases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "MovieRents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "MoviePurchases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WebSeriesRents_WebSeriesId",
                table: "WebSeriesRents",
                column: "WebSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_WebSeriesPurchases_WebSeriesId",
                table: "WebSeriesPurchases",
                column: "WebSeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_WebSeriesPurchases_WebSeriess_WebSeriesId",
                table: "WebSeriesPurchases",
                column: "WebSeriesId",
                principalTable: "WebSeriess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WebSeriesRents_WebSeriess_WebSeriesId",
                table: "WebSeriesRents",
                column: "WebSeriesId",
                principalTable: "WebSeriess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebSeriesPurchases_WebSeriess_WebSeriesId",
                table: "WebSeriesPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_WebSeriesRents_WebSeriess_WebSeriesId",
                table: "WebSeriesRents");

            migrationBuilder.DropIndex(
                name: "IX_WebSeriesRents_WebSeriesId",
                table: "WebSeriesRents");

            migrationBuilder.DropIndex(
                name: "IX_WebSeriesPurchases_WebSeriesId",
                table: "WebSeriesPurchases");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "WebSeriesRents");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "WebSeriesPurchases");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "MovieRents");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "MoviePurchases");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "WebSeriesRents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WebSeriesRents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "WebSeriesRents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "WebSeriesPurchases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WebSeriesPurchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "WebSeriesPurchases",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MovieRents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "MovieRents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MoviePurchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "MoviePurchases",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WebSeriesRents_MovieId",
                table: "WebSeriesRents",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_WebSeriesRents_UserId1",
                table: "WebSeriesRents",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_WebSeriesPurchases_MovieId",
                table: "WebSeriesPurchases",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_WebSeriesPurchases_UserId1",
                table: "WebSeriesPurchases",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRents_UserId1",
                table: "MovieRents",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePurchases_UserId1",
                table: "MoviePurchases",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePurchases_AspNetUsers_UserId1",
                table: "MoviePurchases",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRents_AspNetUsers_UserId1",
                table: "MovieRents",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WebSeriesPurchases_AspNetUsers_UserId1",
                table: "WebSeriesPurchases",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WebSeriesPurchases_Movies_MovieId",
                table: "WebSeriesPurchases",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WebSeriesRents_AspNetUsers_UserId1",
                table: "WebSeriesRents",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WebSeriesRents_Movies_MovieId",
                table: "WebSeriesRents",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
