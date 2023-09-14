using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SistemaAgendamento.Repository.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Agenda_AgendaIdAgenda",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Cliente_ClienteIdCliente",
                table: "Agendamento");

            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_AgendaIdAgenda",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_ClienteIdCliente",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "AgendaIdAgenda",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Agendamento");

            migrationBuilder.AddColumn<int>(
                name: "EstabelecimentoIDEstabelecimentoIdEstabelecimento",
                table: "Agendamento",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeCliente",
                table: "Agendamento",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeProcedimento",
                table: "Agendamento",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_EstabelecimentoIDEstabelecimentoIdEstabelecimento",
                table: "Agendamento",
                column: "EstabelecimentoIDEstabelecimentoIdEstabelecimento");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Estabelecimento_EstabelecimentoIDEstabelecimento~",
                table: "Agendamento",
                column: "EstabelecimentoIDEstabelecimentoIdEstabelecimento",
                principalTable: "Estabelecimento",
                principalColumn: "IdEstabelecimento",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Estabelecimento_EstabelecimentoIDEstabelecimento~",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_EstabelecimentoIDEstabelecimentoIdEstabelecimento",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "EstabelecimentoIDEstabelecimentoIdEstabelecimento",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "NomeCliente",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "NomeProcedimento",
                table: "Agendamento");

            migrationBuilder.AddColumn<int>(
                name: "AgendaIdAgenda",
                table: "Agendamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Agendamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    IdAgenda = table.Column<int>(type: "int", nullable: false),
                    AgendaAberta = table.Column<string>(type: "char", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.IdAgenda);
                    table.ForeignKey(
                        name: "FK_Agenda_Estabelecimento_IdAgenda",
                        column: x => x.IdAgenda,
                        principalTable: "Estabelecimento",
                        principalColumn: "IdEstabelecimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<string>(type: "varchar(1)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_AgendaIdAgenda",
                table: "Agendamento",
                column: "AgendaIdAgenda");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ClienteIdCliente",
                table: "Agendamento",
                column: "ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Agenda_AgendaIdAgenda",
                table: "Agendamento",
                column: "AgendaIdAgenda",
                principalTable: "Agenda",
                principalColumn: "IdAgenda",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Cliente_ClienteIdCliente",
                table: "Agendamento",
                column: "ClienteIdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
