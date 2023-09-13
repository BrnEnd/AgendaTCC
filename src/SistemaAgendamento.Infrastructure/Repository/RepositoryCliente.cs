using Microsoft.EntityFrameworkCore;
using SistemaAgendamento.Domain.Interfaces;
using SistemaAgendamento.Domain.Models;
using SistemaAgendamento.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgendamento.Repository.Repository
{
    public class RepositoryCliente : Repository<Cliente>, IClienteRepository
    {
        public RepositoryCliente(AppDbContext context) : base(context)
        {
        }

        public List<Agendamento> AgendamentosPendentes(int id)
        {
           return _context.Agendamentos.AsTracking().Where(a => a.ClienteIdCliente == id  && a.StatusAgendamento == (int)Status.Espera).ToList();
        }
    }
   
}
