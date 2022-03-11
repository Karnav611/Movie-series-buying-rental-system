using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMovieBuyingRentingSystem.Data.Migrations
{
    public partial class Added_WebSeries_and_WebSeriesCast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WebSeriess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    IMDBRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrailerLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebSeriesFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasePrice = table.Column<int>(type: "int", nullable: false),
                    RentPrice = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebSeriess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebSeriess_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WebSeriesCasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebSeriesId = table.Column<int>(type: "int", nullable: false),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebSeriesCasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebSeriesCasts_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebSeriesCasts_WebSeriess_WebSeriesId",
                        column: x => x.WebSeriesId,
                        principalTable: "WebSeriess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WebSeriesCasts_ActorId",
                table: "WebSeriesCasts",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_WebSeriesCasts_WebSeriesId",
                table: "WebSeriesCasts",
                column: "WebSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_WebSeriess_GenreId",
                table: "WebSeriess",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebSeriesCasts");

            migrationBuilder.DropTable(
                name: "WebSeriess");
        }
    }
}
