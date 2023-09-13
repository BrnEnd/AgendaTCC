using System;

namespace SistemaAgendamento.Repository.DTOs
{
    public class AgendamentoDto
    {
        public Guid IdAgendamento { get; set; }
        public int ClienteIdCliente { get; set; }
        public int AgendaIdAgenda { get; set; }
        public DateTime DiaHoraAgendamento { get; set; }
        public int StatusAgendamento { get; set; }




    }
}
