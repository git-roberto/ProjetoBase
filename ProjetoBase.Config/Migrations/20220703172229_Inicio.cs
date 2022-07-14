using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoBase.Config.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Seguranca");

            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    ID_CLIENTE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_CLIENTE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DS_EMAIL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.ID_CLIENTE);
                });

            migrationBuilder.CreateTable(
                name: "PERFIL",
                schema: "Seguranca",
                columns: table => new
                {
                    ID_PERFIL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_PERFIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CO_PERFIL = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DS_PERFIL = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    FL_ATIVO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFIL", x => x.ID_PERFIL);
                });

            migrationBuilder.CreateTable(
                name: "SISTEMA",
                schema: "Seguranca",
                columns: table => new
                {
                    ID_SISTEMA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_SISTEMA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CO_SISTEMA = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DS_SISTEMA = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    FL_ATIVO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SISTEMA", x => x.ID_SISTEMA);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                schema: "Seguranca",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_LOGIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NM_USUARIO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DS_SENHA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DT_SENHA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FL_BLOQUEADO = table.Column<bool>(type: "bit", nullable: false),
                    FL_ATIVO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "MODULO",
                schema: "Seguranca",
                columns: table => new
                {
                    ID_MODULO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_SISTEMA = table.Column<int>(type: "int", nullable: false),
                    NM_MODULO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CO_MODULO = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DS_MODULO = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    FL_ATIVO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MODULO", x => x.ID_MODULO);
                    table.ForeignKey(
                        name: "FK_MODULO_SISTEMA_ID_SISTEMA",
                        column: x => x.ID_SISTEMA,
                        principalSchema: "Seguranca",
                        principalTable: "SISTEMA",
                        principalColumn: "ID_SISTEMA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PERFIL_USUARIO",
                schema: "Seguranca",
                columns: table => new
                {
                    ID_PERFIL = table.Column<int>(type: "int", nullable: false),
                    ID_USUARIO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFIL_USUARIO", x => new { x.ID_PERFIL, x.ID_USUARIO });
                    table.ForeignKey(
                        name: "FK_PERFIL_USUARIO_PERFIL_ID_PERFIL",
                        column: x => x.ID_PERFIL,
                        principalSchema: "Seguranca",
                        principalTable: "PERFIL",
                        principalColumn: "ID_PERFIL",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PERFIL_USUARIO_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalSchema: "Seguranca",
                        principalTable: "USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FUNCAO",
                schema: "Seguranca",
                columns: table => new
                {
                    ID_FUNCAO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_FUNCAO_PAI = table.Column<int>(type: "int", nullable: true),
                    ID_MODULO = table.Column<int>(type: "int", nullable: false),
                    NM_FUNCAO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CO_FUNCAO = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DS_FUNCAO = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    DS_ROTA = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    TP_VISIBILIDADE = table.Column<int>(type: "int", nullable: false),
                    TP_PERMISSAO = table.Column<int>(type: "int", nullable: false),
                    NU_ORDEM = table.Column<short>(type: "smallint", nullable: false),
                    FL_ATIVO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCAO", x => x.ID_FUNCAO);
                    table.ForeignKey(
                        name: "FK_FUNCAO_FUNCAO_ID_FUNCAO_PAI",
                        column: x => x.ID_FUNCAO_PAI,
                        principalSchema: "Seguranca",
                        principalTable: "FUNCAO",
                        principalColumn: "ID_FUNCAO");
                    table.ForeignKey(
                        name: "FK_FUNCAO_MODULO_ID_MODULO",
                        column: x => x.ID_MODULO,
                        principalSchema: "Seguranca",
                        principalTable: "MODULO",
                        principalColumn: "ID_MODULO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PERFIL_FUNCAO",
                schema: "Seguranca",
                columns: table => new
                {
                    ID_PERFIL_FUNCAO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_PERFIL = table.Column<int>(type: "int", nullable: false),
                    ID_FUNCAO = table.Column<int>(type: "int", nullable: false),
                    FL_CONSULTAR = table.Column<bool>(type: "bit", nullable: false),
                    FL_INSERIR = table.Column<bool>(type: "bit", nullable: false),
                    FL_ALTERAR = table.Column<bool>(type: "bit", nullable: false),
                    FL_EXCLUIR = table.Column<bool>(type: "bit", nullable: false),
                    FL_VISUALIZAR = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFIL_FUNCAO", x => x.ID_PERFIL_FUNCAO);
                    table.ForeignKey(
                        name: "FK_PERFIL_FUNCAO_FUNCAO_ID_FUNCAO",
                        column: x => x.ID_FUNCAO,
                        principalSchema: "Seguranca",
                        principalTable: "FUNCAO",
                        principalColumn: "ID_FUNCAO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PERFIL_FUNCAO_PERFIL_ID_PERFIL",
                        column: x => x.ID_PERFIL,
                        principalSchema: "Seguranca",
                        principalTable: "PERFIL",
                        principalColumn: "ID_PERFIL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FUNCAO_ID_FUNCAO_PAI",
                schema: "Seguranca",
                table: "FUNCAO",
                column: "ID_FUNCAO_PAI");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCAO_ID_MODULO",
                schema: "Seguranca",
                table: "FUNCAO",
                column: "ID_MODULO");

            migrationBuilder.CreateIndex(
                name: "IX_MODULO_ID_SISTEMA",
                schema: "Seguranca",
                table: "MODULO",
                column: "ID_SISTEMA");

            migrationBuilder.CreateIndex(
                name: "IX_PERFIL_FUNCAO_ID_FUNCAO",
                schema: "Seguranca",
                table: "PERFIL_FUNCAO",
                column: "ID_FUNCAO");

            migrationBuilder.CreateIndex(
                name: "IX_PERFIL_FUNCAO_ID_PERFIL",
                schema: "Seguranca",
                table: "PERFIL_FUNCAO",
                column: "ID_PERFIL");

            migrationBuilder.CreateIndex(
                name: "IX_PERFIL_USUARIO_ID_USUARIO",
                schema: "Seguranca",
                table: "PERFIL_USUARIO",
                column: "ID_USUARIO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "PERFIL_FUNCAO",
                schema: "Seguranca");

            migrationBuilder.DropTable(
                name: "PERFIL_USUARIO",
                schema: "Seguranca");

            migrationBuilder.DropTable(
                name: "FUNCAO",
                schema: "Seguranca");

            migrationBuilder.DropTable(
                name: "PERFIL",
                schema: "Seguranca");

            migrationBuilder.DropTable(
                name: "USUARIO",
                schema: "Seguranca");

            migrationBuilder.DropTable(
                name: "MODULO",
                schema: "Seguranca");

            migrationBuilder.DropTable(
                name: "SISTEMA",
                schema: "Seguranca");
        }
    }
}
