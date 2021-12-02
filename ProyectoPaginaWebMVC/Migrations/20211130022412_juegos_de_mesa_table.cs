using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoPaginaWebMVC.Migrations
{
    public partial class juegos_de_mesa_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagenUrl",
                table: "Disenadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "JuegosDeMesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    NumJugadoresMin = table.Column<int>(type: "int", nullable: false),
                    NumJugadoresMax = table.Column<int>(type: "int", nullable: false),
                    DuracionMin = table.Column<int>(type: "int", nullable: false),
                    DuracionMax = table.Column<int>(type: "int", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PortadaUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditorialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuegosDeMesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JuegosDeMesa_Editoriales_EditorialId",
                        column: x => x.EditorialId,
                        principalTable: "Editoriales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JuegosDeMesaCategorias",
                columns: table => new
                {
                    JuegoDeMesaId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuegosDeMesaCategorias", x => new { x.JuegoDeMesaId, x.CategoriaId });
                    table.ForeignKey(
                        name: "FK_JuegosDeMesaCategorias_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuegosDeMesaCategorias_JuegosDeMesa_JuegoDeMesaId",
                        column: x => x.JuegoDeMesaId,
                        principalTable: "JuegosDeMesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JuegosDeMesaDisenadores",
                columns: table => new
                {
                    DisenadorId = table.Column<int>(type: "int", nullable: false),
                    JuegoDeMesaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuegosDeMesaDisenadores", x => new { x.JuegoDeMesaId, x.DisenadorId });
                    table.ForeignKey(
                        name: "FK_JuegosDeMesaDisenadores_Disenadores_DisenadorId",
                        column: x => x.DisenadorId,
                        principalTable: "Disenadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuegosDeMesaDisenadores_JuegosDeMesa_JuegoDeMesaId",
                        column: x => x.JuegoDeMesaId,
                        principalTable: "JuegosDeMesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JuegosDeMesaMecanicas",
                columns: table => new
                {
                    JuegoDeMesaId = table.Column<int>(type: "int", nullable: false),
                    MecanicaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuegosDeMesaMecanicas", x => new { x.JuegoDeMesaId, x.MecanicaId });
                    table.ForeignKey(
                        name: "FK_JuegosDeMesaMecanicas_JuegosDeMesa_JuegoDeMesaId",
                        column: x => x.JuegoDeMesaId,
                        principalTable: "JuegosDeMesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuegosDeMesaMecanicas_Mecanicas_MecanicaId",
                        column: x => x.MecanicaId,
                        principalTable: "Mecanicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JuegosDeMesa_EditorialId",
                table: "JuegosDeMesa",
                column: "EditorialId");

            migrationBuilder.CreateIndex(
                name: "IX_JuegosDeMesaCategorias_CategoriaId",
                table: "JuegosDeMesaCategorias",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_JuegosDeMesaDisenadores_DisenadorId",
                table: "JuegosDeMesaDisenadores",
                column: "DisenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_JuegosDeMesaMecanicas_MecanicaId",
                table: "JuegosDeMesaMecanicas",
                column: "MecanicaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JuegosDeMesaCategorias");

            migrationBuilder.DropTable(
                name: "JuegosDeMesaDisenadores");

            migrationBuilder.DropTable(
                name: "JuegosDeMesaMecanicas");

            migrationBuilder.DropTable(
                name: "JuegosDeMesa");

            migrationBuilder.AlterColumn<string>(
                name: "ImagenUrl",
                table: "Disenadores",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
