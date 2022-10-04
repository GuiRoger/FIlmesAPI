using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesDbConnection.Migrations
{
    public partial class CreateTableIntermediaryIntoFilmeAndCinemaWithSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {           

            migrationBuilder.CreateTable(
                name: "Sessao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaId1 = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    FilmeId = table.Column<int>(type: "int", nullable: false),
                    HorarioDeEncerramento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessao_Cinemas_CinemaId1",
                        column: x => x.CinemaId1,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessao_Filmes_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_CinemaId",
                table: "Sessao",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_CinemaId1",
                table: "Sessao",
                column: "CinemaId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessao");

            migrationBuilder.CreateTable(
                name: "CinemaFilme",
                columns: table => new
                {
                    CinemasId = table.Column<int>(type: "int", nullable: false),
                    FilmesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaFilme", x => new { x.CinemasId, x.FilmesId });
                    table.ForeignKey(
                        name: "FK_CinemaFilme_Cinemas_CinemasId",
                        column: x => x.CinemasId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CinemaFilme_Filmes_FilmesId",
                        column: x => x.FilmesId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaFilme_FilmesId",
                table: "CinemaFilme",
                column: "FilmesId");
        }
    }
}
