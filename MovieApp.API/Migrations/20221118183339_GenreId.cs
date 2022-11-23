using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.API.Migrations
{
    public partial class GenreId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollectionInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackdropPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoviesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackdropPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<int>(type: "int", nullable: true),
                    Homepage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImdbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Revenue = table.Column<double>(type: "float", nullable: true),
                    Runtime = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tagline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoviesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCountry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iso_3166_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoviesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCountry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpokenLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iso_639_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoviesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.GenresId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_MoviesId",
                table: "GenreMovie",
                column: "MoviesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionInfo");

            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.DropTable(
                name: "ProductionCompany");

            migrationBuilder.DropTable(
                name: "ProductionCountry");

            migrationBuilder.DropTable(
                name: "SpokenLanguage");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
