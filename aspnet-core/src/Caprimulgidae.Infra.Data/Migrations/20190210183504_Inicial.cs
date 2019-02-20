using Microsoft.EntityFrameworkCore.Migrations;

namespace Caprimulgidae.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaConhecimentos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaConhecimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estimativas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Priory = table.Column<decimal>(nullable: false),
                    Posteriory = table.Column<decimal>(nullable: false),
                    Probabilidade = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimativas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    PrimeiroNome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    SegundoNome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    Token = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Padrao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ProbabilidadeAcontecer = table.Column<decimal>(nullable: false),
                    ProbabilidadeNaoAcontecer = table.Column<decimal>(nullable: false),
                    IdAreaConhecimento = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_AreaConhecimentos_IdAreaConhecimento",
                        column: x => x.IdAreaConhecimento,
                        principalTable: "AreaConhecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_IdAreaConhecimento",
                table: "Eventos",
                column: "IdAreaConhecimento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estimativas");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "AreaConhecimentos");
        }
    }
}
