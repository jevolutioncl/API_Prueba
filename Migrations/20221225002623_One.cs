using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIPrueba.Migrations
{
    /// <inheritdoc />
    public partial class One : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    IdArtista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreArtista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneroMusical = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.IdArtista);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAlbum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Año = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdArtista = table.Column<int>(type: "int", nullable: false),
                    ArtistaIdArtista = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_Albums_Artistas_ArtistaIdArtista",
                        column: x => x.ArtistaIdArtista,
                        principalTable: "Artistas",
                        principalColumn: "IdArtista");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistaIdArtista",
                table: "Albums",
                column: "ArtistaIdArtista");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artistas");
        }
    }
}
