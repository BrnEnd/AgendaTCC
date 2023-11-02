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
        public string AddNewAgendamento(Agendamento agendamento);

        public string CancelarAgendamento(Agendamento agendamento);
        public string AlterarAgendamento(Agendamento agendamento);
        public Estabelecimento GetEstabelecimentoByName(string estabelecimento);
    }
}
