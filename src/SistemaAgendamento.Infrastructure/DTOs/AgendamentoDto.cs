using System;

namespace SistemaAgendamento.Repository.DTOs
{
    public class AgendamentoDto
    {
        public Guid IdAgendamento { get; set; }
        public string NomeCliente { get; set; }
        public string NomeProcedimento { get; set; }
        public string NomeEstabelecimento { get; set; }
        public DateTime DiaHoraAgendamento { get; set; }
        public int StatusAgendamento { get; set; }




    }
}
