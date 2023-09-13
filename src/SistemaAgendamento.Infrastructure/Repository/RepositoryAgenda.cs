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
    public class RepositoryAgenda : Repository<Agenda>, IAgendaRepository
    {
        public RepositoryAgenda(AppDbContext context) : base(context)
        {
        }
    }
}
