using SistemaAgendamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgendamento.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
       List<Agendamento> AgendamentosPendentes(int id);
    }
}
