using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgendamento.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IEstabelecimentoRepository EstabelecimentoRepository { get; }
        IAgendamentoRepository AgendamentoRepository { get; }
        IClienteRepository ClienteRepository { get; }
        IAgendaRepository AgendaRepository { get; }

        void Commit();
    }
}
