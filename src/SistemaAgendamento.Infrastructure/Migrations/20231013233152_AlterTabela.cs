using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaAgendamento.Repository.Migrations
{
    public partial class AlterTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "NomeEstabelecimento",
                table: "Agendamento",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeEstabelecimento",
                table: "Agendamento");

            migrationBuilder.AddColumn<int>(
                name: "EstabelecimentoIDEstabelecimentoIdEstabelecimento",
                table: "Agendamento",
                type: "int",
                nullable: true);

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
    }
}
