using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bluetrip.Migrations
{
    /// <inheritdoc />
    public partial class CriaTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Rua = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Cep = table.Column<string>(type: "NVARCHAR2(9)", maxLength: 9, nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    Complemento = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.EnderecoId);
                });

            migrationBuilder.CreateTable(
                name: "TURISTA",
                columns: table => new
                {
                    TuristaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TURISTA", x => x.TuristaId);
                });

            migrationBuilder.CreateTable(
                name: "PONTOTURISTICO",
                columns: table => new
                {
                    PontoTuristicoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(512)", maxLength: 512, nullable: false),
                    Preco = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    UrlImagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Categoria = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PONTOTURISTICO", x => x.PontoTuristicoId);
                    table.ForeignKey(
                        name: "FK_PONTOTURISTICO_ENDERECO_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "ENDERECO",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EVENTO",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(512)", maxLength: 512, nullable: false),
                    Preco = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    UrlImagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "DATE", nullable: false),
                    DataFim = table.Column<DateTime>(type: "DATE", nullable: false),
                    PontoTuristicoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENTO", x => x.EventoId);
                    table.ForeignKey(
                        name: "FK_EVENTO_PONTOTURISTICO_PontoTuristicoId",
                        column: x => x.PontoTuristicoId,
                        principalTable: "PONTOTURISTICO",
                        principalColumn: "PontoTuristicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AGENDAMENTO",
                columns: table => new
                {
                    AgendamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    QuantidadePessoas = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TuristaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENDAMENTO", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_AGENDAMENTO_EVENTO_EventoId",
                        column: x => x.EventoId,
                        principalTable: "EVENTO",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AGENDAMENTO_TURISTA_TuristaId",
                        column: x => x.TuristaId,
                        principalTable: "TURISTA",
                        principalColumn: "TuristaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AGENDAMENTO_EventoId",
                table: "AGENDAMENTO",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_AGENDAMENTO_TuristaId",
                table: "AGENDAMENTO",
                column: "TuristaId");

            migrationBuilder.CreateIndex(
                name: "IX_EVENTO_PontoTuristicoId",
                table: "EVENTO",
                column: "PontoTuristicoId");

            migrationBuilder.CreateIndex(
                name: "IX_PONTOTURISTICO_EnderecoId",
                table: "PONTOTURISTICO",
                column: "EnderecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AGENDAMENTO");

            migrationBuilder.DropTable(
                name: "EVENTO");

            migrationBuilder.DropTable(
                name: "TURISTA");

            migrationBuilder.DropTable(
                name: "PONTOTURISTICO");

            migrationBuilder.DropTable(
                name: "ENDERECO");
        }
    }
}
