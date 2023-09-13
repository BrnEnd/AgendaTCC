using SistemaAgendamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgendamento.Domain.Interfaces
{
    public interface IAgendamentoRepository : IRepository<Agendamento>
    {
        public string AddNewAgendamento(Agendamento agendamento, Cliente cliente, Agenda agenda);

        public string CancelarAgendamento(Agendamento agendamento);
    }
}
